﻿/// Copyright 2012 Darren Kopp
///
/// Licensed under the Apache License, Version 2.0 (the "License");
/// you may not use this file except in compliance with the License.
/// You may obtain a copy of the License at
///
///    http://www.apache.org/licenses/LICENSE-2.0
///
/// Unless required by applicable law or agreed to in writing, software
/// distributed under the License is distributed on an "AS IS" BASIS,
/// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
/// See the License for the specific language governing permissions and
/// limitations under the License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace TaleOfTwoWastelands.Patching.Murmur
{
    public abstract class Murmur128 : HashAlgorithm
    {
        private readonly uint _Seed;
        protected Murmur128(uint seed)
        {
            _Seed = seed;
        }

        public uint Seed { get { return _Seed; } }

        public static Murmur128 Create()
        {
            if (Environment.Is64BitProcess)
                return new Murmur128UnmanagedX64();

            return new Murmur128UnmanagedX86();
        }
    }
}