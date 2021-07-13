﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Tensorflow.Binding;

namespace Tensorflow.NumPy
{
    public partial class NDArray
    {
        Tensor _tensor;
        public TF_DataType dtype => _tensor.dtype;
        public ulong size => _tensor.size;
        public ulong dtypesize => _tensor.dtypesize;
        public ulong bytesize => _tensor.bytesize;
        public int ndim => _tensor.ndim;
        public long[] dims => _tensor.dims.Select(x => Convert.ToInt64(x)).ToArray();
        public Shape shape => _tensor.shape;
        public IntPtr data => _tensor.TensorDataPointer;

        public T GetValue<T>(int index) where T : unmanaged
            => _tensor.ToArray<T>()[index];
        public T GetAtIndex<T>(int index) where T : unmanaged
            => _tensor.ToArray<T>()[index]; 
        public T[] GetData<T>() where T : unmanaged
            => _tensor.ToArray<T>();

        public NDArray[] GetNDArrays()
            => throw new NotImplementedException("");

        public ValueType GetValue(params int[] indices)
            => throw new NotImplementedException("");

        public void SetData(object value, params int[] indices)
            => throw new NotImplementedException("");

        public NDIterator<T> AsIterator<T>(bool autoreset = false) where T : unmanaged
            => throw new NotImplementedException("");

        public bool HasNext() => throw new NotImplementedException("");
        public T MoveNext<T>() => throw new NotImplementedException("");
        public NDArray reshape(Shape newshape) => new NDArray(_tensor, newshape);
        public NDArray astype(Type type) => new NDArray(math_ops.cast(_tensor, type.as_tf_dtype()));
        public NDArray astype(TF_DataType dtype) => new NDArray(math_ops.cast(_tensor, dtype));
        public NDArray ravel() => throw new NotImplementedException("");
        public void shuffle(NDArray nd) => throw new NotImplementedException("");
        public Array ToMuliDimArray<T>() => throw new NotImplementedException("");
        public byte[] ToByteArray() => _tensor.BufferToArray();
        public static string[] AsStringArray(NDArray arr) => throw new NotImplementedException("");

        public T[] Data<T>() where T : unmanaged
            => _tensor.ToArray<T>();
        public T[] ToArray<T>() where T : unmanaged
            => _tensor.ToArray<T>();

        public static NDArray operator /(NDArray x, NDArray y) => throw new NotImplementedException("");

        public override string ToString()
        {
            return tensor_util.to_numpy_string(_tensor);
        }
    }
}