﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IController 
{
    void ControllerInitialize();

    void ControllerUpdate();

    void ControllerFinalize();
}
