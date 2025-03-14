namespace ScePSX;

public enum Interrupt
{
	VBLANK = 1,
	GPU = 2,
	CDROM = 4,
	DMA = 8,
	TIMER0 = 0x10,
	TIMER1 = 0x20,
	TIMER2 = 0x40,
	CONTR = 0x80,
	SIO = 0x100,
	SPU = 0x200,
	PIO = 0x400
}
