﻿//******************************************************************************************************
//  MemoryStream.cs - Gbtc
//
//  Copyright © 2012, Grid Protection Alliance.  All Rights Reserved.
//
//  Licensed to the Grid Protection Alliance (GPA) under one or more contributor license agreements. See
//  the NOTICE file distributed with this work for additional information regarding copyright ownership.
//  The GPA licenses this file to you under the Eclipse Public License -v 1.0 (the "License"); you may
//  not use this file except in compliance with the License. You may obtain a copy of the License at:
//
//      http://www.opensource.org/licenses/eclipse-1.0.php
//
//  Unless agreed to in writing, the subject software distributed under the License is distributed on an
//  "AS-IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. Refer to the
//  License for the specific language governing permissions and limitations.
//
//  Code Modification History:
//  ----------------------------------------------------------------------------------------------------
//  5/1/2012 - Steven E. Chisholm
//       Generated original version of source code. 
//       
//
//******************************************************************************************************

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using openHistorian.V2.UnmanagedMemory;

namespace openHistorian.V2.IO.Unmanaged
{
    /// <summary>
    /// Provides a in memory stream that uses pages that are pooled in the unmanaged buffer pool.
    /// </summary>
    unsafe public partial class MemoryStream
    {
        // Nested Types
        class IoSession : IBinaryStreamIoSession
        {
            bool m_disposed;
            MemoryStream m_stream;

            public IoSession(MemoryStream stream)
            {
                m_stream = stream;
            }

            /// <summary>
            /// Releases the unmanaged resources before the <see cref="IoSession"/> object is reclaimed by <see cref="GC"/>.
            /// </summary>
            ~IoSession()
            {
                Dispose(false);
            }

            /// <summary>
            /// Releases all the resources used by the <see cref="IoSession"/> object.
            /// </summary>
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            /// <summary>
            /// Releases the unmanaged resources used by the <see cref="IoSession"/> object and optionally releases the managed resources.
            /// </summary>
            /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
            protected virtual void Dispose(bool disposing)
            {
                if (!m_disposed)
                {
                    try
                    {
                        // This will be done regardless of whether the object is finalized or disposed.
                        if (disposing)
                        {
                            // This will be done only when the object is disposed by calling Dispose().
                        }
                    }
                    finally
                    {
                        m_disposed = true;  // Prevent duplicate dispose.
                    }
                }
            }

            public void GetBlock(long position, bool isWriting, out IntPtr firstPointer, out long firstPosition, out int length, out bool supportsWriting)
            {
                m_stream.GetBlock(position, isWriting, out firstPointer, out firstPosition, out length, out supportsWriting);
            }


            public void Clear()
            {

            }


            public bool IsDisposed
            {
                get
                {
                    return m_disposed;
                }
            }
        }
    }
}
