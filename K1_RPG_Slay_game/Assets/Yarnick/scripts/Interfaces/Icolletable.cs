﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Icolletable
{
  //int Weight { get; set; }
  int Rarity { get; set; }
  int _itemId { get; set; }
  void CollectItem();
}