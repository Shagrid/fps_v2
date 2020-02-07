using UnityEngine;
using Views;

namespace Geekbrains
{
    public sealed class FlashLightController : BaseController, IExecute, IInitialization
    {
        private FlashLightModel _flashLightModel;
        private FlashLightUiBar _flashLightUiBar;

        public void Initialization()
        {
            _flashLightModel = Object.FindObjectOfType<FlashLightModel>();
            _flashLightUiBar = Object.FindObjectOfType<FlashLightUiBar>();
        }

        public override void On()
        {
            if(IsActive) return;
            if (_flashLightModel.BatteryChargeCurrent <= 0) return;
            base.On();
            _flashLightModel.Switch(FlashLightActiveType.On);
        }

        public override void Off()
        {
            if (!IsActive) return;
            base.Off();
            _flashLightModel.Switch(FlashLightActiveType.Off);
        }

        public void Execute()
        {
            if (!IsActive && _flashLightModel.BatteryFull())
            {
                return;
            }
            

            _flashLightModel.Rotation();
            if (_flashLightModel.EditBatteryCharge())
            {
                _flashLightUiBar.Fill = _flashLightModel.BatteryChargeCurrent/_flashLightModel.BatteryChargeMax;
                _flashLightUiBar.SetColor(_flashLightModel.LowBattery() ? Color.red : Color.yellow);
            }
            else
            {
                Off();
            }
            
        }
    }
}
