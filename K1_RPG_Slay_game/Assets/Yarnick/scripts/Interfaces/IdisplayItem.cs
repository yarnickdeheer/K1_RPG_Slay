using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public interface IDisplayItem
{
    Image ItemImage { get; set; }
    int ItemId { get; set; }
}
