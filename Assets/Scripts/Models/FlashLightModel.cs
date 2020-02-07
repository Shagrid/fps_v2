using System;
using UnityEngine;

namespace Geekbrains
{
    public sealed class FlashLightModel : BaseObjectScene
    {
        private Light _light;
        private Transform _goFollow;
        private Vector3 _vecOffset;
        private float _lowBatteryRatio = 4;
        public float BatteryChargeCurrent { get; private set; }
        [SerializeField] private float _battaryChargeSpeed = 4;
        [SerializeField] private float _batteryChargeMax = 10;
        [SerializeField] private float _speed = 11;
        public float BatteryChargeMax => _batteryChargeMax;

        protected override void Awake()
        {
            base.Awake();
            _light = GetComponent<Light>();
            _goFollow = Camera.main.transform;
            _vecOffset = transform.position - _goFollow.position;
            BatteryChargeCurrent = BatteryChargeMax;
        }

        public void Switch(FlashLightActiveType value)
        {
            switch (value)
            {
                case FlashLightActiveType.On:
                    _light.enabled = true;
                    transform.position = _goFollow.position + _vecOffset;
                    transform.rotation = _goFollow.rotation;
                    break;
                case FlashLightActiveType.None:
                    break;
                case FlashLightActiveType.Off:
                    _light.enabled = false;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(value), value, null);
            }
        }

        public void Rotation()
        {
            transform.position = _goFollow.position + _vecOffset;
            transform.rotation = Quaternion.Lerp(transform.rotation,
                _goFollow.rotation, _speed * Time.deltaTime);
        }

        public bool EditBatteryCharge()
        {
            if (BatteryChargeCurrent > 0 && _light.enabled)
            {
                BatteryChargeCurrent -= Time.deltaTime;
                return true;
            }
            if (BatteryChargeCurrent < _batteryChargeMax && !_light.enabled)
            {
                BatteryChargeCurrent += Time.deltaTime / _battaryChargeSpeed;
                if (BatteryChargeCurrent > BatteryChargeMax)
                {
                    BatteryChargeCurrent = BatteryChargeMax;
                }
                return true;
            }
            return false;
        }

        public bool LowBattery()
        {
            return BatteryChargeCurrent <= BatteryChargeMax / _lowBatteryRatio;
        }

        public bool BatteryFull()
        {
            return BatteryChargeCurrent == BatteryChargeMax;
        }
    }
}
