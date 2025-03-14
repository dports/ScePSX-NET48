using System;

namespace ScePSX.Disassembler;

[Serializable]
internal class BIOS_Disassembler
{
	private BUS bus;

	private string msg = "";

	public BIOS_Disassembler(BUS bus)
	{
		this.bus = bus;
	}

	internal void verbose(uint PC, uint[] GPR)
	{
		uint num = PC & 0x1FFFFFFF;
		uint num2 = GPR[9];
		uint num3 = GPR[4];
		uint num4 = GPR[5];
		uint value = GPR[6];
		uint value2 = GPR[7];
		switch (num)
		{
		case 160u:
			msg = $"[BIOS] [Function A {num2:x2}] ";
			switch (num2)
			{
			case 0u:
			case 1u:
				msg += "FileSeek(fd, offset, seektype)";
				break;
			case 2u:
				msg += "FileRead(fd, dst, length)";
				break;
			case 3u:
				msg += "FileWrite(fd, src, length)";
				break;
			case 4u:
				msg += "FileClose(fd)";
				break;
			case 5u:
				msg += "FileIoctl(fd, cmd, arg)";
				break;
			case 6u:
				msg += "exit(exitcode)";
				break;
			case 7u:
				msg += "FileGetDeviceFlag(fd)";
				break;
			case 8u:
				msg += "FileGetc(fd)";
				break;
			case 9u:
				msg += "FilePutc(char, fd)";
				break;
			case 10u:
				msg += "todigit(char)";
				break;
			case 11u:
				msg += "atof(src); Does NOT work - uses(ABSENT) cop1!!!";
				break;
			case 12u:
				msg += "strtoul(src, src_end, base)";
				break;
			case 13u:
				msg += "strtol(src, src_end, base)";
				break;
			case 14u:
				msg += "abs(val)";
				break;
			case 15u:
				msg += "labs(val)";
				break;
			case 16u:
				msg += "atoi(src)";
				break;
			case 17u:
				msg += "atol(src)";
				break;
			case 18u:
				msg += "atob(src,num_dst)";
				break;
			case 19u:
				msg += "SaveState(buf)";
				break;
			case 20u:
				msg += "RestoreState(buf,param)";
				break;
			case 21u:
				msg += $"strcat({biosOutput(num3)},{biosOutput(num4)})";
				break;
			case 22u:
				msg += $"strncat({biosOutput(num3)},{biosOutput(num4)},{value})";
				break;
			case 23u:
				msg += $"strcmp({biosOutput(num3)},{biosOutput(num4)})";
				break;
			case 24u:
				msg += $"strncmp({biosOutput(num3)},{biosOutput(num4)},{value})";
				break;
			case 25u:
				msg += $"strcpy({biosOutput(num3)},{biosOutput(num4)})";
				break;
			case 26u:
				msg += $"strncpy({biosOutput(num3)},{biosOutput(num4)},{value})";
				break;
			case 27u:
				msg = msg + "strlen(" + biosOutput(num3) + ")";
				break;
			case 28u:
				msg += "index(src,char)";
				break;
			case 29u:
				msg += "rindex(src,char)";
				break;
			case 30u:
				msg += "strchr(src,char";
				break;
			case 31u:
				msg += " strrchr(src,char)";
				break;
			case 32u:
				msg += "strpbrk(src,list)";
				break;
			case 33u:
				msg += "strspn(src,list)";
				break;
			case 34u:
				msg += "strcspn(src,list)";
				break;
			case 35u:
				msg += "strtok(src,list)";
				break;
			case 36u:
				msg += "strstr(str,substr)";
				break;
			case 37u:
				msg += "toupper(char)";
				break;
			case 38u:
				msg += "tolower(char)";
				break;
			case 39u:
				msg += "bcopy(src,dst,len)";
				break;
			case 40u:
				msg += $"bzero(dst = {num3:x8},len = {num4:x8})";
				break;
			case 41u:
				msg += "bcmp(ptr1,ptr2,len";
				break;
			case 42u:
				msg += "memcpy(dst,src,len)";
				break;
			case 43u:
				msg += "memset(dst,fillbyte,len)";
				break;
			case 44u:
				msg += "memmove(dst,src,len)";
				break;
			case 45u:
				msg += "memcmp(src1,src2,len)";
				break;
			case 46u:
				msg += "memchr(src,scanbyte,len)";
				break;
			case 47u:
				msg += "rand()";
				break;
			case 48u:
				msg += "srand(seed)";
				break;
			case 49u:
				msg += "qsort(base,nel,width,callback)";
				break;
			case 50u:
				msg += "strtod(src,src_end)";
				break;
			case 51u:
				msg += "malloc(size)";
				break;
			case 52u:
				msg += "free(buf)";
				break;
			case 53u:
				msg += "lsearch(key,base,nel,width,callback)";
				break;
			case 54u:
				msg += "bsearch(key,base,nel,width,callback)";
				break;
			case 55u:
				msg += "calloc(sizx,sizy)";
				break;
			case 56u:
				msg += "realloc(old_buf,new_siz)";
				break;
			case 57u:
				msg += "InitHeap(addr,size)";
				break;
			case 58u:
				msg += "SystemErrorExit(exitcode)";
				break;
			case 59u:
				msg += "std_in_getchar()";
				break;
			case 60u:
				msg += "std_out_putchar(char)";
				break;
			case 61u:
				msg += "std_in_gets(dst)";
				break;
			case 62u:
				msg += "std_out_puts(src)";
				break;
			case 63u:
				msg += "printf(txt,param1,param2,etc.)";
				break;
			case 64u:
				msg += "SystemErrorUnresolvedException()";
				break;
			case 65u:
				msg += "LoadExeHeader(filename,headerbuf)";
				break;
			case 66u:
				msg += "LoadExeFile(filename,headerbuf)";
				break;
			case 67u:
				msg += "DoExecute(headerbuf,param1,param2)";
				break;
			case 68u:
				msg += "FlushCache()";
				break;
			case 69u:
				msg += "init_a0_b0_c0_vectors";
				break;
			case 70u:
				msg += "GPU_dw(Xdst,Ydst,Xsiz,Ysiz,src)";
				break;
			case 71u:
				msg += "gpu_send_dma(Xdst,Ydst,Xsiz,Ysiz,src)";
				break;
			case 72u:
				msg += "SendGP1Command(gp1cmd)";
				break;
			case 73u:
				msg += "GPU_cw(gp0cmd)";
				break;
			case 74u:
				msg += "GPU_cwp(src,num)";
				break;
			case 75u:
				msg += "send_gpu_linked_list(src)";
				break;
			case 76u:
				msg += "gpu_abort_dma()";
				break;
			case 77u:
				msg += "GetGPUStatus()";
				break;
			case 78u:
				msg += "gpu_sync()";
				break;
			case 79u:
			case 80u:
				msg += "SystemError";
				break;
			case 81u:
				msg += "LoadAndExecute(filename,stackbase,stackoffset)";
				break;
			case 82u:
				msg += "SystemError ----OR---- GetSysSp()";
				break;
			case 83u:
				msg += "SystemError           ;PS2: set_ioabort_handler(src)";
				break;
			case 84u:
				msg += "CdInit()";
				break;
			case 85u:
				msg += "_bu_init()";
				break;
			case 86u:
				msg += "CdRemove()";
				break;
			case 87u:
			case 88u:
			case 89u:
			case 90u:
				msg += "return 0";
				break;
			case 91u:
				msg += "dev_tty_init()  ";
				break;
			case 92u:
				msg += "dev_tty_open(fcb,and unused:'path\name',accessmode)";
				break;
			case 93u:
				msg += "dev_tty_in_out(fcb,cmd) ";
				break;
			case 94u:
				msg += "dev_tty_ioctl(fcb,cmd,arg)";
				break;
			case 95u:
				msg += "dev_cd_open(fcb,'path\name',accessmode)";
				break;
			case 96u:
				msg += "dev_cd_read(fcb,dst,len)";
				break;
			case 97u:
				msg += "dev_cd_close(fcb)";
				break;
			case 98u:
				msg += "dev_cd_firstfile(fcb,'path\name',direntry)";
				break;
			case 99u:
				msg += "dev_cd_nextfile(fcb,direntry)";
				break;
			case 100u:
				msg += "dev_cd_chdir(fcb,'path')";
				break;
			case 101u:
				msg += "dev_card_open(fcb,'path\name',accessmode)";
				break;
			case 102u:
				msg += "dev_card_read(fcb,dst,len)";
				break;
			case 103u:
				msg += "dev_card_write(fcb,src,len)";
				break;
			case 104u:
				msg += "dev_card_close(fcb)";
				break;
			case 105u:
				msg += "dev_card_firstfile(fcb,'path\name',direntry)";
				break;
			case 106u:
				msg += "dev_card_nextfile(fcb,direntry)";
				break;
			case 107u:
				msg += "dev_card_erase(fcb,'path\name')";
				break;
			case 108u:
				msg += "dev_card_undelete(fcb,'path\name')";
				break;
			case 109u:
				msg += "dev_card_format(fcb)";
				break;
			case 110u:
				msg += "dev_card_rename(fcb1,'path\name1',fcb2,'path\name2')";
				break;
			case 111u:
				msg += "?   ;card ;[r4+18h]=00000000h  ;card_clear_error(fcb) or so";
				break;
			case 112u:
				msg += "_bu_init()";
				break;
			case 113u:
				msg += "CdInit()";
				break;
			case 114u:
				msg += "CdRemove()";
				break;
			case 115u:
			case 116u:
			case 117u:
			case 118u:
			case 119u:
				msg += "return 0";
				break;
			case 120u:
				msg += $"CdAsyncSeekL({num3:x8})";
				break;
			case 121u:
			case 122u:
			case 123u:
				msg += "return 0";
				break;
			case 124u:
				msg += $"CdAsyncGetStatus({num3:x8})";
				break;
			case 125u:
				msg += "return 0";
				break;
			case 126u:
				msg += $"CdAsyncReadSector({num3:x8)},{num4:x8},{value:x8})";
				break;
			case 127u:
			case 128u:
				msg += "return 0";
				break;
			case 129u:
				msg += $"CdAsyncSetMode({num3})";
				break;
			case 130u:
			case 131u:
			case 132u:
			case 133u:
			case 134u:
			case 135u:
			case 136u:
			case 137u:
			case 138u:
			case 139u:
			case 140u:
			case 141u:
			case 142u:
			case 143u:
				msg += "return 0";
				break;
			case 144u:
				msg += "CdromIoIrqFunc1()";
				break;
			case 145u:
				msg += "CdromDmaIrqFunc1()";
				break;
			case 146u:
				msg += "CdromIoIrqFunc2()";
				break;
			case 147u:
				msg += "CdromDmaIrqFunc2()";
				break;
			case 148u:
				msg += "CdromGetInt5errCode(dst1,dst2)";
				break;
			case 149u:
				msg += "CdInitSubFunc()";
				break;
			case 150u:
				msg += "AddCDROMDevice()";
				break;
			case 151u:
				msg += "AddMemCardDevice()";
				break;
			case 152u:
				msg += "AddDuartTtyDevice()";
				break;
			case 153u:
				msg += "AddDummyTtyDevice(";
				break;
			case 154u:
			case 155u:
				msg += "SystemError";
				break;
			case 156u:
				msg += "SetConf(num_EvCB,num_TCB,stacktop)";
				break;
			case 157u:
				msg += "GetConf(num_EvCB_dst,num_TCB_dst,stacktop_dst)";
				break;
			case 158u:
				msg += "SetCdromIrqAutoAbort(type, flag)";
				break;
			case 159u:
				msg += "SetMemSize(megabytes)";
				break;
			case 160u:
				msg += "WarmBoot()";
				break;
			case 161u:
				msg += $"SystemErrorBootOrDiskFailure({(ushort)num3},{num4:x8})";
				break;
			case 162u:
				msg += "EnqueueCdIntr()";
				break;
			case 163u:
				msg += "DequeueCdIntr()";
				break;
			case 164u:
				msg += "CdGetLbn(filename)";
				break;
			case 165u:
				msg += "CdReadSector(count,sector,buffer)";
				break;
			case 166u:
				msg += "CdGetStatus()";
				break;
			case 167u:
				msg += "bu_callback_okay()";
				break;
			case 168u:
				msg += "bu_callback_err_write()";
				break;
			case 169u:
				msg += "bu_callback_err_busy()";
				break;
			case 170u:
				msg += "bu_callback_err_eject()";
				break;
			case 171u:
				msg += "_card_info(port)";
				break;
			case 172u:
				msg += "_card_async_load_directory(port)";
				break;
			case 173u:
				msg += "set_card_auto_format(flag)";
				break;
			case 174u:
				msg += "bu_callback_err_prev_write()";
				break;
			case 175u:
				msg += "card_write_test(port)";
				break;
			case 176u:
			case 177u:
				msg += "return 0";
				break;
			case 178u:
				msg += "ioabort_raw(param)";
				break;
			case 179u:
				msg += "return 0";
				break;
			case 180u:
				msg += "GetSystemInfo(index)";
				break;
			default:
				if (num >= 181 && num <= 191)
				{
					msg += "jump_to_00000000h";
				}
				break;
			}
			log(msg);
			break;
		case 176u:
			msg = $"[BIOS] [Function B {num2:x2}] ";
			switch (num2)
			{
			case 0u:
				msg += "alloc_kernel_memory(size)";
				break;
			case 1u:
				msg += "free_kernel_memory(buf)";
				break;
			case 2u:
				msg += "init_timer(t,reload,flags)";
				break;
			case 3u:
				msg += "get_timer(t)";
				break;
			case 4u:
				msg += "enable_timer_irq(t)";
				break;
			case 5u:
				msg += "disable_timer_irq(t)";
				break;
			case 6u:
				msg += "restart_timer(t)";
				break;
			case 7u:
				msg += $"DeliverEvent(class = {num3:x8}, spec = {num4:x8})";
				break;
			case 8u:
				msg += $"OpenEvent(class = {num3:x8},spec = {num4:x8},mode = {value:x8},func = {value2:x8})";
				break;
			case 9u:
				msg += $"CloseEvent(event = {num3:x8})";
				break;
			case 10u:
				msg += $"WaitEvent(event = {num3:x8})";
				break;
			case 11u:
				return;
			case 12u:
				msg += $"EnableEvent(event = {num3:x8})";
				break;
			case 13u:
				msg += $"DisableEvent(event = {num3:x8})";
				break;
			case 14u:
				msg += "OpenThread(reg_PC,reg_SP_FP,reg_GP)";
				break;
			case 15u:
				msg += "CloseThread(handle)";
				break;
			case 16u:
				msg += "ChangeThread(handle)";
				break;
			case 17u:
				msg += "jump_to_00000000h";
				break;
			case 18u:
				msg += "InitPad(buf1,siz1,buf2,siz2)";
				break;
			case 19u:
				msg += "StartPad()";
				break;
			case 20u:
				msg += "StopPad()";
				break;
			case 21u:
				msg += "OutdatedPadInitAndStart(type,button_dest,unused,unused)";
				break;
			case 22u:
				msg += "OutdatedPadGetButtons()";
				break;
			case 23u:
				return;
			case 24u:
				msg += "SetDefaultExitFromException()";
				break;
			case 25u:
				msg += "SetCustomExitFromException(addr)";
				break;
			case 26u:
			case 27u:
			case 28u:
			case 29u:
			case 30u:
			case 31u:
				msg += "SystemError  ;PS2: return 0";
				break;
			case 32u:
				msg += $"UnDeliverEvent({num3.ToString("x8")},{num4.ToString("x8")})";
				break;
			case 33u:
			case 34u:
			case 35u:
				msg += "SystemError  ;PS2: return 0";
				break;
			case 36u:
			case 37u:
			case 38u:
			case 39u:
			case 40u:
			case 41u:
				msg += "jump_to_00000000h";
				break;
			case 42u:
			case 43u:
				msg += "SystemError  ;PS2: return 0";
				break;
			case 44u:
			case 45u:
			case 46u:
			case 47u:
			case 48u:
			case 49u:
				msg += "jump_to_00000000h";
				break;
			case 50u:
				msg += $"FileOpen({num3.ToString("x8")},{num4}) {biosOutput(num3)}";
				break;
			case 51u:
				msg += "FileSeek(fd,offset,seektype)";
				break;
			case 52u:
				msg += "FileRead(fd,dst,length)";
				break;
			case 53u:
				msg += "FileWrite(fd,src,length)";
				break;
			case 54u:
				msg += "FileClose(fd)";
				break;
			case 55u:
				msg += "FileIoctl(fd,cmd,arg)";
				break;
			case 56u:
				msg += "exit(exitcode)";
				break;
			case 57u:
				msg += "FileGetDeviceFlag(fd)";
				break;
			case 58u:
				msg += "FileGetc(fd)";
				break;
			case 59u:
				msg += "FilePutc(char,fd)";
				break;
			case 60u:
				msg += "std_in_getchar()";
				break;
			case 61u:
				return;
			case 62u:
				msg += "std_in_gets(dst)";
				break;
			case 63u:
				msg += "std_out_puts(src)";
				break;
			case 64u:
				msg += "chdir(name)";
				break;
			case 65u:
				msg += "FormatDevice(devicename)";
				break;
			case 66u:
				msg += "firstfile(filename,direntry)";
				break;
			case 67u:
				msg += "nextfile(direntry)";
				break;
			case 68u:
				msg += "FileRename(old_filename,new_filename)";
				break;
			case 69u:
				msg += "FileDelete(filename)";
				break;
			case 70u:
				msg += "FileUndelete(filename)";
				break;
			case 71u:
				msg += "AddDevice(device_info)";
				break;
			case 72u:
				msg += "RemoveDevice(device_name_lowercase)";
				break;
			case 73u:
				msg += "PrintInstalledDevices()";
				break;
			case 74u:
				msg += "InitCard(pad_enable)";
				break;
			case 75u:
				msg += "StartCard()";
				break;
			case 76u:
				msg += "StopCard()";
				break;
			case 77u:
				msg += "_card_info_subfunc(port)";
				break;
			case 78u:
				msg += "write_card_sector(port,sector,src)";
				break;
			case 79u:
				msg += "read_card_sector(port,sector,dst)";
				break;
			case 80u:
				msg += "allow_new_card()";
				break;
			case 81u:
				msg += "Krom2RawAdd(shiftjis_code)";
				break;
			case 82u:
				msg += "SystemError  ;PS2: return 0";
				break;
			case 83u:
				msg += "Krom2Offset(shiftjis_code)";
				break;
			case 84u:
				msg += "GetLastError()";
				break;
			case 85u:
				msg += "GetLastFileError(fd)";
				break;
			case 86u:
				msg += "GetC0Table";
				break;
			case 87u:
				msg += "GetB0Table";
				break;
			case 88u:
				msg += "get_bu_callback_port()";
				break;
			case 89u:
				msg += "testdevice(devicename)";
				break;
			case 90u:
				msg += "SystemError  ;PS2: return 0";
				break;
			case 91u:
				msg += "ChangeClearPad(int)";
				break;
			case 92u:
				msg += "get_card_status(slot)";
				break;
			case 93u:
				msg += "wait_card_status(slot)";
				break;
			default:
				if (num >= 94 && num <= 255)
				{
					msg += "jump_to_00000000h";
				}
				break;
			}
			log(msg);
			break;
		case 192u:
			msg = $"[BIOS] [Function C {num2:x2}] ";
			switch (num2)
			{
			case 0u:
				msg += "EnqueueTimerAndVblankIrqs(priority) ;used with prio=1";
				break;
			case 1u:
				msg += "EnqueueSyscallHandler(priority)     ;used with prio=0";
				break;
			case 2u:
				msg += "SysEnqIntRP(priority,struc)  ;bugged, use with care";
				break;
			case 3u:
				msg += "SysDeqIntRP(priority,struc)  ;bugged, use with care";
				break;
			case 4u:
				msg += "get_free_EvCB_slot()";
				break;
			case 5u:
				msg += "get_free_TCB_slot()";
				break;
			case 6u:
				msg += "ExceptionHandler()";
				break;
			case 7u:
				msg += "InstallExceptionHandlers()  ;destroys/uses k0/k1";
				break;
			case 8u:
				msg += "SysInitMemory(addr,size)";
				break;
			case 9u:
				msg += "SysInitKernelVariables()";
				break;
			case 10u:
				msg += "ChangeClearRCnt(t,flag)";
				break;
			case 11u:
				msg += "SystemError  ;PS2: return 0";
				break;
			case 12u:
				msg += "InitDefInt(priority) ;used with prio=3";
				break;
			case 13u:
				msg += "SetIrqAutoAck(irq,flag)";
				break;
			case 14u:
				msg += "return 0               ;DTL-H2000: dev_sio_init";
				break;
			case 15u:
				msg += "return 0               ;DTL-H2000: dev_sio_open";
				break;
			case 16u:
				msg += "return 0               ;DTL-H2000: dev_sio_in_out";
				break;
			case 17u:
				msg += "return 0               ;DTL-H2000: dev_sio_ioctl";
				break;
			case 18u:
				msg += "InstallDevices(ttyflag)";
				break;
			case 19u:
				msg += "FlushStdInOutPut()";
				break;
			case 20u:
				msg += "return 0               ;DTL-H2000: SystemError";
				break;
			case 21u:
				msg += "tty_cdevinput(circ,char)";
				break;
			case 22u:
				msg += " tty_cdevscan()";
				break;
			case 23u:
				msg += "tty_circgetc(circ)    ;uses r5 as garbage txt for ioabort";
				break;
			case 24u:
				msg += "tty_circputc(char,circ)";
				break;
			case 25u:
				msg += "ioabort(txt1,txt2)";
				break;
			case 26u:
				msg += "set_card_find_mode(mode)  ;0=normal, 1=find deleted files";
				break;
			case 27u:
				msg += "KernelRedirect(ttyflag)   ;PS2: ttyflag=1 causes SystemError";
				break;
			case 28u:
				msg += "AdjustA0Table()";
				break;
			case 29u:
				msg += "get_card_find_mode()";
				break;
			default:
				if (num >= 30 && num <= 126)
				{
					msg += "jump_to_00000000h";
				}
				else if (num >= 128 && num <= 255)
				{
					msg = msg + "MIRROR Function launching B " + (num2 - 128).ToString("x2");
					GPR[9] = GPR[9] - 128;
					verbose(176u, GPR);
				}
				break;
			}
			log(msg);
			break;
		}
	}

	private void log(string msg)
	{
		Console.ForegroundColor = ConsoleColor.Blue;
		Console.WriteLine(msg);
		Console.ResetColor();
	}

	private string biosOutput(uint addr)
	{
		string text = "";
		for (char c = (char)bus.read32(addr++); c != 0; c = (char)bus.read32(addr++))
		{
			text += c;
		}
		return text;
	}
}
