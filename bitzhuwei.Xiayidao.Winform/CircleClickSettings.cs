using System;
using System.Xml.Linq;
namespace bitzhuwei.Xiayidao.Winform
{
	internal class CircleClickSettings
	{
		public const string strCircleClickSettings = "CircleClickSettings";
		private const string strCirclrX = "CircleX";
		private const string strCirclrY = "CircleY";
		private const string strMinRadius = "MinRadius";
		private const string strMaxRadius = "MaxRadius";
		private const string strBack = "Back";
		private const string strSimulateMouse = "SimulateMouse";
		private const string strNoSkill = "NoSkill";
		private const string strNoSkillInterval = "NoSkillInterval";
		private const string strHand = "Hand";
		private const string strHandFirst = "HandFirst";
		private const string strPointDistance = "PointDistance";
		private const string strRoundDistance = "RoundDistance";
		private const string strTimeInterval = "TimeInterval";
		private const string strRunAwayXueYao = "RunAwayXueYao";
		private const string strRunAwayLanYao = "RunAwayLanYao";
		public int _circleX = 611;
		public int _circleY = 293;
		public int _minRadius = 20;
		public int _maxRadius = 300;
		public bool _back = true;
		public bool _simulateMouse = true;
		public bool _noSkill;
		public int _noSkillInterval = 10000;
		public bool _hand = true;
		public bool _handFirst;
		public int _pointDistance = 15;
		public int _roundDistance = 24;
		public int _timeInterval = 20;
		public int _runAwayXueYao = 20;
		public int _runAwayLanYao = 20;
		public XElement ToXElement()
		{
			return new XElement("CircleClickSettings", new object[]
			{
				new XAttribute("CircleX", this._circleX),
				new XAttribute("CircleY", this._circleY),
				new XAttribute("MinRadius", this._minRadius),
				new XAttribute("MaxRadius", this._maxRadius),
				new XAttribute("Back", this._back),
				new XAttribute("SimulateMouse", this._simulateMouse),
				new XAttribute("NoSkill", this._noSkill),
				new XAttribute("NoSkillInterval", this._noSkillInterval),
				new XAttribute("Hand", this._hand),
				new XAttribute("HandFirst", this._handFirst),
				new XAttribute("PointDistance", this._pointDistance),
				new XAttribute("RoundDistance", this._roundDistance),
				new XAttribute("TimeInterval", this._timeInterval),
				new XAttribute("RunAwayXueYao", this._runAwayXueYao),
				new XAttribute("RunAwayLanYao", this._runAwayLanYao)
			});
		}
		public static CircleClickSettings From(XElement xCircleClickSettings)
		{
			if (xCircleClickSettings == null || xCircleClickSettings.Name != "CircleClickSettings")
			{
				return null;
			}
			return new CircleClickSettings
			{
				_circleX = int.Parse(xCircleClickSettings.Attribute("CircleX").Value),
				_circleY = int.Parse(xCircleClickSettings.Attribute("CircleY").Value),
				_minRadius = int.Parse(xCircleClickSettings.Attribute("MinRadius").Value),
				_maxRadius = int.Parse(xCircleClickSettings.Attribute("MaxRadius").Value),
				_back = bool.Parse(xCircleClickSettings.Attribute("Back").Value),
				_simulateMouse = bool.Parse(xCircleClickSettings.Attribute("SimulateMouse").Value),
				_noSkill = bool.Parse(xCircleClickSettings.Attribute("NoSkill").Value),
				_noSkillInterval = int.Parse(xCircleClickSettings.Attribute("NoSkillInterval").Value),
				_hand = bool.Parse(xCircleClickSettings.Attribute("Hand").Value),
				_handFirst = bool.Parse(xCircleClickSettings.Attribute("HandFirst").Value),
				_pointDistance = int.Parse(xCircleClickSettings.Attribute("PointDistance").Value),
				_roundDistance = int.Parse(xCircleClickSettings.Attribute("RoundDistance").Value),
				_timeInterval = int.Parse(xCircleClickSettings.Attribute("TimeInterval").Value),
				_runAwayXueYao = int.Parse(xCircleClickSettings.Attribute("RunAwayXueYao").Value),
				_runAwayLanYao = int.Parse(xCircleClickSettings.Attribute("RunAwayLanYao").Value)
			};
		}
		internal void Save(string strConfigFile)
		{
			this.ToXElement().Save(strConfigFile);
		}
	}
}
