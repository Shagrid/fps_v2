using UnityEngine;

namespace Geekbrains
{
	public sealed class UiInterface
	{
		private FlashLightUiBar _flashLightUiBar;

		public FlashLightUiBar FlashLightUiBar
		{
			get
			{
				if (!_flashLightUiBar)
					_flashLightUiBar = Object.FindObjectOfType<FlashLightUiBar>();
				return _flashLightUiBar;
			}
		}
		

		private SelectionObjectMessageUi _selectionObjMessageUi;

		public SelectionObjectMessageUi SelectionObjMessageUi
		{
			get
			{
				if (!_selectionObjMessageUi)
					_selectionObjMessageUi = Object.FindObjectOfType<SelectionObjectMessageUi>();
				return _selectionObjMessageUi;
			}
		}
	}
}