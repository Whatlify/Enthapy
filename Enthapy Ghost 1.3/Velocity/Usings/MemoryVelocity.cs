using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ns0
{
	public sealed class MemoryVelocity
	{
		public IntPtr intptr_0 = IntPtr.Zero;

		public static int int_0;

		public MemoryVelocity(uint uint_0)
		{
			intptr_0 = Class2.OpenProcess(2035711u, bool_0: false, (int)uint_0);
		}

		private List<GStruct0> method_0()
		{
			List<GStruct0> list = new List<GStruct0>();
			GStruct1 gstruct1_;
			for (long num = 0L; Class2.VirtualQueryEx(intptr_0, num, out gstruct1_, (uint)Marshal.SizeOf(typeof(GStruct1))); num += (long)gstruct1_.ulong_0)
			{
				if (gstruct1_.genum2_0 == GEnum2.const_0 && gstruct1_.genum1_1 == GEnum1.const_2 && num != 0L)
				{
					byte[] array = new byte[gstruct1_.ulong_0];
					Class2.NtReadVirtualMemory(intptr_0, num, array, (uint)array.Length, 0u);
					list.Add(new GStruct0(num, array));
				}
			}
			return list;
		}

		public T method_1<T>(long long_0) where T : struct
		{
			byte[] array = new byte[Marshal.SizeOf(typeof(T))];
			Class2.ReadProcessMemory((int)intptr_0, long_0, array, array.Length, ref int_0);
			return smethod_0<T>(array);
		}

		public List<long> method_2(double double_0)
		{
			List<long> list = new List<long>();
			foreach (GStruct0 item in method_0())
			{
				for (uint num = 0u; num < item.buf.Length; num += 8)
				{
					if (BitConverter.ToDouble(item.buf, (int)num) == double_0)
					{
						list.Add(item._base + num);
					}
				}
			}
			return list;
		}

		public void method_3(long long_0, double double_0)
		{
			byte[] bytes = BitConverter.GetBytes(double_0);
			Class2.NtWriteVirtualMemory(intptr_0, long_0, bytes, 8u, 0u);
		}

		private static T smethod_0<T>(byte[] byte_0) where T : struct
		{
			GCHandle gCHandle = GCHandle.Alloc(byte_0, GCHandleType.Pinned);
			try
			{
				return (T)Marshal.PtrToStructure(gCHandle.AddrOfPinnedObject(), typeof(T));
			}
			finally
			{
				gCHandle.Free();
			}
		}
	}
}
