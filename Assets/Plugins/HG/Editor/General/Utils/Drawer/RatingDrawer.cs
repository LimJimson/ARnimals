using System;
using System.Globalization;
using HG.Extensions;
using UnityEditor;
using UnityEngine;

namespace HG
{
    public interface IRatingPersistence
    {
        bool DontShowAgain { get; set; }
        DateTime? NextShowTime { get; set; }
    }

    // @LATER add cached decorator if will be called often
    public class RatingPersistence : IRatingPersistence
    {
        private readonly string _uniquePrefix;

        private string DontShowAgainKey
        {
            get { return _uniquePrefix + "DontShowAgainKey"; }
        }

        private string NextShowTimeKey 
        {
            get { return _uniquePrefix + "NextShowTimeKey"; }
        }

        public RatingPersistence(string uniquePrefix)
        {
            _uniquePrefix = uniquePrefix;
        }

        public bool DontShowAgain
        {
            get { return EditorPrefs.GetBool(DontShowAgainKey, false); }
            set { EditorPrefs.SetBool(DontShowAgainKey, value); }
        }

        public DateTime? NextShowTime
        {
            get { return GetDateTime(NextShowTimeKey);}
            set { SetDateTime(value, NextShowTimeKey);}
        }

        private const string PrefsTimeFormat = "yyyyMMdd";
        
        private void SetDateTime(DateTime? value, string prefsKey)
        {
            if (!value.HasValue)
            {
                throw new ArgumentNullException("can't set null");
            }

            EditorPrefs.SetString(prefsKey,
                value.Value.ToString(PrefsTimeFormat, CultureInfo.InvariantCulture));
        }

        private DateTime? GetDateTime(string prefsKey)
        {
            string strDate = EditorPrefs.GetString(prefsKey, null);
            if (strDate.IsNullOrEmpty()) return null;

            DateTime parsedDate;
            if (DateTime.TryParseExact(strDate, PrefsTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None,
                out parsedDate))
            {
                return parsedDate;
            }
            else
            {
                return null;
            }
        }
    }
    
    public class RatingDrawer : IDrawer
    {
        private readonly string _ratingUrl;
        private readonly int _firstDaysDelay;
        private readonly int _remindDaysDelay;
        private readonly RatingPersistence _persistence;
        
        private readonly VerticalSequenceDrawer _mainDrawer = new VerticalSequenceDrawer();
        private bool _showRating = false;
        
        public RatingDrawer(string ratingUrl, string uniquePrefix, int firstDaysDelay = 3, int remindDaysDelay = 7)
        {
            _persistence = new RatingPersistence(uniquePrefix);
            
            //DEBUG
            //UnityEditor.EditorPrefs.DeleteAll();
            //_persistence.NextShowTime = DateTime.Now.AddDays(-1);
            //
            
            _ratingUrl = ratingUrl;
            _firstDaysDelay = firstDaysDelay;
            _remindDaysDelay = remindDaysDelay;

            if (_persistence.DontShowAgain)
            {
                _showRating = false;
            }
            else
            {
                if (!_persistence.NextShowTime.HasValue)
                {
                    _persistence.NextShowTime = DateTime.Now.AddDays(_firstDaysDelay);
                    _showRating = false;
                }
                else if (DateTime.Now >= _persistence.NextShowTime)
                {
                    _showRating = true;
                }
                else
                {
                    // wait for next
                    _showRating = false;
                }
            }

            AddFullDrawer();
        }

        private void AddFullDrawer()
        {
            _mainDrawer.SetStyle(EditorStyles.helpBox);
            _mainDrawer.AddDrawer(new Label.Label("Rating").SetBold(true));
            
            var line1 = new HorizontalSequenceDrawer();
            line1.AddDrawer(new Space(10));
            line1.AddDrawer(new Label.Label("Enjoying using this plugin?\nConsider leaving a review, this would help me a great deal."));
            
            var line2 = new HorizontalSequenceDrawer();
            line2.AddDrawer(new Space(10));
            line2.AddDrawer(CreateButton("Rate", OnRatePressed));
            line2.AddDrawer(CreateButton("Remind Later", OnRemindPressed));
            line2.AddDrawer(CreateButton("Don't Show Again", OnDontShowPressed));
            
            _mainDrawer.AddDrawer(line1);
            _mainDrawer.AddDrawer(line2);
        }

        private IDrawer CreateButton(string text, Action onPress)
        {
            // width 100 is enough for Unity 2018, but not for 2019
            // @LATER calculate the correct button width based on the current style: https://docs.unity3d.com/ScriptReference/GUIStyle.CalcSize.html
            return new Button.Button(text, onPress).SetStyle(EditorStyles.miniButton).SetWidth(115); 
        }

        private void OnDontShowPressed()
        {
            _persistence.DontShowAgain = true;
            _showRating = false;
        }

        private void OnRemindPressed()
        {
            _persistence.NextShowTime = DateTime.Now.AddDays(_remindDaysDelay);
            _showRating = false;
        }

        private void OnRatePressed()
        {
            Application.OpenURL(_ratingUrl);
            _persistence.DontShowAgain = true;
            _showRating = false;
        }

        public void Draw()
        {
            if (_showRating)
            {
                _mainDrawer.Draw();
            }
        }
    }
}