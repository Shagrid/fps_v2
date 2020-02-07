using GeekBrains;
using UnityEngine;

namespace Geekbrains
{
    public sealed class FlashLightController : BaseController, IExecute, IInitialization
    {
        private FlashLightModel _flashLightModel;
        
        public void Initialization()
        {
            _flashLightModel = Object.FindObjectOfType<FlashLightModel>();
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
                UiInterface.FlashLightUiBar.Fill = _flashLightModel.BatteryChargeCurrent/_flashLightModel.BatteryChargeMax;
                UiInterface.FlashLightUiBar.SetColor(_flashLightModel.LowBattery() ? Color.red : Color.yellow);
            }
            else
            {
                Off();
            }
            
        }
    }
}
