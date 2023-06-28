 
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class BottomShortcut : UIBase
{
    // ButShortcut
    private Button ButShortcut;
    private Text DouNum;

    public void Start()
    {
        ButShortcut = transform.Find("ButShortcut").GetComponent<Button>();
        DouNum = transform.Find("DouNum").GetComponent<Text>();
        DouNum.text = "X "+(GameCache.player!=null?GameCache.player.douNum:0);
        ButShortcut.onClick.AddListener(ButShortcutClick);
    }

    private void ButShortcutClick()
    {
        Dispatch(AreaCode.UI, UIEvent.SHORT_CUT_TIPS_ACTIVE, true);
    }
}