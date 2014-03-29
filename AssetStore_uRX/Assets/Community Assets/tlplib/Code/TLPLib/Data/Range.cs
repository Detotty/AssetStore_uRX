﻿using System;
using System.Collections;
using System.Collections.Generic;
using com.tinylabproductions.TLPLib.Utilities;
using UnityEngine;
using Random = UnityEngine.Random;

namespace com.tinylabproductions.TLPLib.Data {
  [Serializable]
  public class Range {
    // No it can't, Unity...
    // ReSharper disable once FieldCanBeMadeReadOnly.Local
    [SerializeField] private int _from, _to;
    public int from { get { return _from; } }
    public int to { get { return _to; } }

    public Range(int from, int to) {
      _from = from;
      _to = to;
    }

    public int random { get { return Random.Range(from, to + 1); } }
  }

  [Serializable]
  public struct URange {
    public readonly uint from, to;

    public URange(uint from, uint to) {
      this.from = from;
      this.to = to;
    }

    public uint random { get { return (uint) Random.Range(from, to + 1); } }
  }

  [Serializable]
  public class FRange {
    // No it can't, Unity...
    // ReSharper disable once FieldCanBeMadeReadOnly.Local
    [SerializeField] private float _from, _to;
    public float from { get { return _from; } }
    public float to { get { return _to; } }

    public FRange(float from, float to) {
      _from = from;
      _to = to;
    }

    public float random { get { return Rng.range(from, to); } }

    public EnumerableFRange by(float step) {
      return new EnumerableFRange(from, to, step);
    }

    public override string ToString() {
      return string.Format("({0} to {1})", from, to);
    }
  }

  public struct EnumerableFRange : IEnumerable<float> {
    public readonly float from, to, step;

    public EnumerableFRange(float from, float to, float step) {
      this.from = from;
      this.to = to;
      this.step = step;
    }

    public float random { get { return Rng.range(from, to); } }

    public IEnumerator<float> GetEnumerator() {
      for (var i = from; i <= to; i += step)
        yield return i;
    }

    IEnumerator IEnumerable.GetEnumerator() {
      return GetEnumerator();
    }

    public override string ToString() {
      return string.Format("({0} to {1} by {2})", from, to, step);
    }
  }
}
