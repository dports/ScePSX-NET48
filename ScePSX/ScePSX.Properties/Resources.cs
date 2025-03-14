using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace ScePSX.Properties;

[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
[DebuggerNonUserCode]
[CompilerGenerated]
internal class Resources
{
	private static ResourceManager resourceMan;

	private static CultureInfo resourceCulture;

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static ResourceManager ResourceManager
	{
		get
		{
			if (resourceMan == null)
			{
				resourceMan = new ResourceManager("ScePSX.Properties.Resources", typeof(Resources).Assembly);
			}
			return resourceMan;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static CultureInfo Culture
	{
		get
		{
			return resourceCulture;
		}
		set
		{
			resourceCulture = value;
		}
	}

	internal static string about => ResourceManager.GetString("about", resourceCulture);

	internal static string BackToMain => ResourceManager.GetString("BackToMain", resourceCulture);

	internal static string CheatCode => ResourceManager.GetString("CheatCode", resourceCulture);

	internal static string cutline => ResourceManager.GetString("cutline", resourceCulture);

	internal static string debug => ResourceManager.GetString("debug", resourceCulture);

	internal static string FastSpeed => ResourceManager.GetString("FastSpeed", resourceCulture);

	internal static string File => ResourceManager.GetString("File", resourceCulture);

	internal static string Font => ResourceManager.GetString("Font", resourceCulture);

	internal static string Form_Cheat_btnadd_Click_新建 => ResourceManager.GetString("Form_Cheat_btnadd_Click_新建", resourceCulture);

	internal static string Form_Cheat_Form_Cheat_的金手指 => ResourceManager.GetString("Form_Cheat_Form_Cheat_的金手指", resourceCulture);

	internal static string Form_Cheat_InitializeComponent_保存 => ResourceManager.GetString("Form_Cheat_InitializeComponent_保存", resourceCulture);

	internal static string Form_Cheat_InitializeComponent_删除 => ResourceManager.GetString("Form_Cheat_InitializeComponent_删除", resourceCulture);

	internal static string Form_Cheat_InitializeComponent_地址代码 => ResourceManager.GetString("Form_Cheat_InitializeComponent_地址代码", resourceCulture);

	internal static string Form_Cheat_InitializeComponent_增加 => ResourceManager.GetString("Form_Cheat_InitializeComponent_增加", resourceCulture);

	internal static string Form_Cheat_InitializeComponent_导入 => ResourceManager.GetString("Form_Cheat_InitializeComponent_导入", resourceCulture);

	internal static string Form_Cheat_InitializeComponent_应用金手指 => ResourceManager.GetString("Form_Cheat_InitializeComponent_应用金手指", resourceCulture);

	internal static string Form_Cheat_InitializeComponent_读取 => ResourceManager.GetString("Form_Cheat_InitializeComponent_读取", resourceCulture);

	internal static string Form_Cheat_InitializeComponent_金手指 => ResourceManager.GetString("Form_Cheat_InitializeComponent_金手指", resourceCulture);

	internal static string Form_McrMange_Cbsave1_SelectedIndexChanged_同名 => ResourceManager.GetString("Form_McrMange_Cbsave1_SelectedIndexChanged_同名", resourceCulture);

	internal static string Form_McrMange_InitializeComponent_Import => ResourceManager.GetString("Form_McrMange_InitializeComponent_Import", resourceCulture);

	internal static string Form_McrMange_InitializeComponent_MemcardMange => ResourceManager.GetString("Form_McrMange_InitializeComponent_MemcardMange", resourceCulture);

	internal static string Form_McrMange_InitializeComponent_保存修改 => ResourceManager.GetString("Form_McrMange_InitializeComponent_保存修改", resourceCulture);

	internal static string Form_McrMange_InitializeComponent_删除选中 => ResourceManager.GetString("Form_McrMange_InitializeComponent_删除选中", resourceCulture);

	internal static string Form_McrMange_InitializeComponent_存档管理 => ResourceManager.GetString("Form_McrMange_InitializeComponent_存档管理", resourceCulture);

	internal static string Form_McrMange_InitializeComponent_导出 => ResourceManager.GetString("Form_McrMange_InitializeComponent_导出", resourceCulture);

	internal static string Form_McrMange_move1to2_Click_空位 => ResourceManager.GetString("Form_McrMange_move1to2_Click_空位", resourceCulture);

	internal static string Form_Mem_InitializeComponent_内存搜索 => ResourceManager.GetString("Form_Mem_InitializeComponent_内存搜索", resourceCulture);

	internal static string Form_Mem_InitializeComponent_内存编辑 => ResourceManager.GetString("Form_Mem_InitializeComponent_内存编辑", resourceCulture);

	internal static string Form_Mem_InitializeComponent_刷新 => ResourceManager.GetString("Form_Mem_InitializeComponent_刷新", resourceCulture);

	internal static string Form_Mem_InitializeComponent_前往地址 => ResourceManager.GetString("Form_Mem_InitializeComponent_前往地址", resourceCulture);

	internal static string Form_Mem_InitializeComponent_双字DWORD => ResourceManager.GetString("Form_Mem_InitializeComponent_双字DWORD", resourceCulture);

	internal static string Form_Mem_InitializeComponent_地址 => ResourceManager.GetString("Form_Mem_InitializeComponent_地址", resourceCulture);

	internal static string Form_Mem_InitializeComponent_字WORD => ResourceManager.GetString("Form_Mem_InitializeComponent_字WORD", resourceCulture);

	internal static string Form_Mem_InitializeComponent_字节Byte => ResourceManager.GetString("Form_Mem_InitializeComponent_字节Byte", resourceCulture);

	internal static string Form_Mem_InitializeComponent_搜索 => ResourceManager.GetString("Form_Mem_InitializeComponent_搜索", resourceCulture);

	internal static string Form_Mem_InitializeComponent_搜索到0个地址只显示前500个 => ResourceManager.GetString("Form_Mem_InitializeComponent_搜索到0个地址只显示前500个", resourceCulture);

	internal static string Form_Mem_InitializeComponent_搜索类型 => ResourceManager.GetString("Form_Mem_InitializeComponent_搜索类型", resourceCulture);

	internal static string Form_Mem_InitializeComponent_数值 => ResourceManager.GetString("Form_Mem_InitializeComponent_数值", resourceCulture);

	internal static string Form_Mem_InitializeComponent_浮点Float => ResourceManager.GetString("Form_Mem_InitializeComponent_浮点Float", resourceCulture);

	internal static string Form_Mem_InitializeComponent_自动刷新 => ResourceManager.GetString("Form_Mem_InitializeComponent_自动刷新", resourceCulture);

	internal static string Form_Mem_InitializeComponent_重置 => ResourceManager.GetString("Form_Mem_InitializeComponent_重置", resourceCulture);

	internal static string Form_Mem_updateml_个地址只显示前500个 => ResourceManager.GetString("Form_Mem_updateml_个地址只显示前500个", resourceCulture);

	internal static string Form_Mem_updateml_搜索到 => ResourceManager.GetString("Form_Mem_updateml_搜索到", resourceCulture);

	internal static string Form_Set_Form_Set_set => ResourceManager.GetString("Form_Set_Form_Set_set", resourceCulture);

	internal static string Form_Set_InitializeComponent_audio => ResourceManager.GetString("Form_Set_InitializeComponent_audio", resourceCulture);

	internal static string Form_Set_InitializeComponent_bt => ResourceManager.GetString("Form_Set_InitializeComponent_bt", resourceCulture);

	internal static string Form_Set_InitializeComponent_con => ResourceManager.GetString("Form_Set_InitializeComponent_con", resourceCulture);

	internal static string Form_Set_InitializeComponent_CPUt => ResourceManager.GetString("Form_Set_InitializeComponent_CPUt", resourceCulture);

	internal static string Form_Set_InitializeComponent_cyles => ResourceManager.GetString("Form_Set_InitializeComponent_cyles", resourceCulture);

	internal static string Form_Set_InitializeComponent_fsk => ResourceManager.GetString("Form_Set_InitializeComponent_fsk", resourceCulture);

	internal static string Form_Set_InitializeComponent_gbs => ResourceManager.GetString("Form_Set_InitializeComponent_gbs", resourceCulture);

	internal static string Form_Set_InitializeComponent_GPU分辨率 => ResourceManager.GetString("Form_Set_InitializeComponent_GPU分辨率", resourceCulture);

	internal static string Form_Set_InitializeComponent_limit => ResourceManager.GetString("Form_Set_InitializeComponent_limit", resourceCulture);

	internal static string Form_Set_InitializeComponent_PGXP几何校正 => ResourceManager.GetString("Form_Set_InitializeComponent_PGXP几何校正", resourceCulture);

	internal static string Form_Set_InitializeComponent_save => ResourceManager.GetString("Form_Set_InitializeComponent_save", resourceCulture);

	internal static string Form_Set_InitializeComponent_不清楚作用的设置尽量不要修改 => ResourceManager.GetString("Form_Set_InitializeComponent_不清楚作用的设置尽量不要修改", resourceCulture);

	internal static string Form_Set_InitializeComponent_内部分辨率放大 => ResourceManager.GetString("Form_Set_InitializeComponent_内部分辨率放大", resourceCulture);

	internal static string Form_Set_InitializeComponent_完整指令模式 => ResourceManager.GetString("Form_Set_InitializeComponent_完整指令模式", resourceCulture);

	internal static string Form_Set_InitializeComponent_性能优化模式 => ResourceManager.GetString("Form_Set_InitializeComponent_性能优化模式", resourceCulture);

	internal static string Form_Set_InitializeComponent_真彩色渲染 => ResourceManager.GetString("Form_Set_InitializeComponent_真彩色渲染", resourceCulture);

	internal static string Form_Set_InitializeComponent_自适应 => ResourceManager.GetString("Form_Set_InitializeComponent_自适应", resourceCulture);

	internal static string Form_Set_InitializeComponent_设置 => ResourceManager.GetString("Form_Set_InitializeComponent_设置", resourceCulture);

	internal static string Form_Set_InitializeComponent_透视校正 => ResourceManager.GetString("Form_Set_InitializeComponent_透视校正", resourceCulture);

	internal static string Frameskip => ResourceManager.GetString("Frameskip", resourceCulture);

	internal static string FrmAbout_InitializeComponent_read => ResourceManager.GetString("FrmAbout_InitializeComponent_read", resourceCulture);

	internal static string FrmAbout_InitializeComponent_read2 => ResourceManager.GetString("FrmAbout_InitializeComponent_read2", resourceCulture);

	internal static string FrmAbout_InitializeComponent_关于 => ResourceManager.GetString("FrmAbout_InitializeComponent_关于", resourceCulture);

	internal static string FrmAbout_InitializeComponent_维护者 => ResourceManager.GetString("FrmAbout_InitializeComponent_维护者", resourceCulture);

	internal static string FrmInput_InitializeComponent_保存设置 => ResourceManager.GetString("FrmInput_InitializeComponent_保存设置", resourceCulture);

	internal static string FrmInput_InitializeComponent_按下 => ResourceManager.GetString("FrmInput_InitializeComponent_按下", resourceCulture);

	internal static string FrmInput_InitializeComponent_按键设置 => ResourceManager.GetString("FrmInput_InitializeComponent_按键设置", resourceCulture);

	internal static string FrmMain_LoadRom_nobios => ResourceManager.GetString("FrmMain_LoadRom_nobios", resourceCulture);

	internal static string FrmMain_SaveState_saved => ResourceManager.GetString("FrmMain_SaveState_saved", resourceCulture);

	internal static string FrmMain_SwapDisc_更换光盘 => ResourceManager.GetString("FrmMain_SwapDisc_更换光盘", resourceCulture);

	internal static string FrmMain_Timer_Elapsed_多轴手柄 => ResourceManager.GetString("FrmMain_Timer_Elapsed_多轴手柄", resourceCulture);

	internal static string FrmMain_Timer_Elapsed_存档槽 => ResourceManager.GetString("FrmMain_Timer_Elapsed_存档槽", resourceCulture);

	internal static string FrmMain_Timer_Elapsed_手柄优先 => ResourceManager.GetString("FrmMain_Timer_Elapsed_手柄优先", resourceCulture);

	internal static string FrmMain_Timer_Elapsed_数字手柄 => ResourceManager.GetString("FrmMain_Timer_Elapsed_数字手柄", resourceCulture);

	internal static string FrmMain_Timer_Elapsed_暂停中 => ResourceManager.GetString("FrmMain_Timer_Elapsed_暂停中", resourceCulture);

	internal static string FrmMain_Timer_Elapsed_键盘优先 => ResourceManager.GetString("FrmMain_Timer_Elapsed_键盘优先", resourceCulture);

	internal static string FrmNetPlay_btncli_Click_已启用客户机模式 => ResourceManager.GetString("FrmNetPlay_btncli_Click_已启用客户机模式", resourceCulture);

	internal static string FrmNetPlay_btnsrv_Click_已启用主机模式 => ResourceManager.GetString("FrmNetPlay_btnsrv_Click_已启用主机模式", resourceCulture);

	internal static string FrmNetPlay_InitializeComponent_作为主机启动 => ResourceManager.GetString("FrmNetPlay_InitializeComponent_作为主机启动", resourceCulture);

	internal static string FrmNetPlay_InitializeComponent_作为主机时的IP地址 => ResourceManager.GetString("FrmNetPlay_InitializeComponent_作为主机时的IP地址", resourceCulture);

	internal static string FrmNetPlay_InitializeComponent_作为客户机启动 => ResourceManager.GetString("FrmNetPlay_InitializeComponent_作为客户机启动", resourceCulture);

	internal static string FrmNetPlay_InitializeComponent_未启动网络对战 => ResourceManager.GetString("FrmNetPlay_InitializeComponent_未启动网络对战", resourceCulture);

	internal static string FrmNetPlay_InitializeComponent_目标主机的IP地址 => ResourceManager.GetString("FrmNetPlay_InitializeComponent_目标主机的IP地址", resourceCulture);

	internal static string KeySet => ResourceManager.GetString("KeySet", resourceCulture);

	internal static string LoadDIsk => ResourceManager.GetString("LoadDIsk", resourceCulture);

	internal static string LoadState => ResourceManager.GetString("LoadState", resourceCulture);

	internal static string memedit => ResourceManager.GetString("memedit", resourceCulture);

	internal static string netplay => ResourceManager.GetString("netplay", resourceCulture);

	internal static string netplayset => ResourceManager.GetString("netplayset", resourceCulture);

	internal static string pause => ResourceManager.GetString("pause", resourceCulture);

	internal static string Render => ResourceManager.GetString("Render", resourceCulture);

	internal static string RomList_DrawInfoBoxes_即时存档 => ResourceManager.GetString("RomList_DrawInfoBoxes_即时存档", resourceCulture);

	internal static string RomList_DrawInfoBoxes_最后运行 => ResourceManager.GetString("RomList_DrawInfoBoxes_最后运行", resourceCulture);

	internal static string RomList_DrawInfoBoxes_金手指 => ResourceManager.GetString("RomList_DrawInfoBoxes_金手指", resourceCulture);

	internal static string RomList_RomList_修改设置 => ResourceManager.GetString("RomList_RomList_修改设置", resourceCulture);

	internal static string RomList_RomList_删除 => ResourceManager.GetString("RomList_RomList_删除", resourceCulture);

	internal static string RomList_RomList_取存档图标 => ResourceManager.GetString("RomList_RomList_取存档图标", resourceCulture);

	internal static string RomList_RomList_存档管理 => ResourceManager.GetString("RomList_RomList_存档管理", resourceCulture);

	internal static string RomList_RomList_编辑金手指 => ResourceManager.GetString("RomList_RomList_编辑金手指", resourceCulture);

	internal static string RomList_RomList_设置图标 => ResourceManager.GetString("RomList_RomList_设置图标", resourceCulture);

	internal static string RomList_SearchDir_是否要搜索子目录 => ResourceManager.GetString("RomList_SearchDir_是否要搜索子目录", resourceCulture);

	internal static string SaveState => ResourceManager.GetString("SaveState", resourceCulture);

	internal static string SearchDir => ResourceManager.GetString("SearchDir", resourceCulture);

	internal static string Setting => ResourceManager.GetString("Setting", resourceCulture);

	internal static string SwapDisc => ResourceManager.GetString("SwapDisc", resourceCulture);

	internal static string UnLoad => ResourceManager.GetString("UnLoad", resourceCulture);

	internal Resources()
	{
	}
}
