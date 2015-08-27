﻿// Copyright 2012 Richard Dingwall - http://richarddingwall.name
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace ProtoBuf.Data.Internal
{
    using System;
    using System.Collections.Generic;

    internal static class ConvertProtoDataType
    {
        private static readonly IDictionary<Type, ProtoDataType> Mapping
            = new Dictionary<Type, ProtoDataType>
                  {
                      { typeof(bool), ProtoDataType.Bool },
                      { typeof(byte), ProtoDataType.Byte },
                      { typeof(DateTime), ProtoDataType.DateTime },
                      { typeof(double), ProtoDataType.Double },
                      { typeof(float), ProtoDataType.Float },
                      { typeof(Guid), ProtoDataType.Guid },
                      { typeof(int), ProtoDataType.Int },
                      { typeof(long), ProtoDataType.Long },
                      { typeof(short), ProtoDataType.Short },
                      { typeof(string), ProtoDataType.String },
                      { typeof(char), ProtoDataType.Char },
                      { typeof(decimal), ProtoDataType.Decimal },
                      { typeof(byte[]), ProtoDataType.ByteArray },
                      { typeof(char[]), ProtoDataType.CharArray },
                      { typeof(TimeSpan), ProtoDataType.TimeSpan },
                      {typeof(DateTimeOffset), ProtoDataType.DateTimeOffset},
                  };

        public static ProtoDataType FromClrType(Type type)
        {
            ProtoDataType value;
            if (Mapping.TryGetValue(type, out value))
            {
                return value;
            }

            throw new UnsupportedColumnTypeException(type);
        }

        public static Type ToClrType(ProtoDataType type)
        {
            foreach (var pair in Mapping)
            {
                if (pair.Value.Equals(type))
                {
                    return pair.Key;
                }
            }

            throw new InvalidOperationException("Unknown ProtoDataType.");
        }
    }
}