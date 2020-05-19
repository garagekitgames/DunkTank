// Copyright (c) 2015 - 2020 Doozy Entertainment. All Rights Reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

// ReSharper disable InconsistentNaming

namespace Doozy.Editor
{
    /// <summary> Defines variable names that are used to retrieve serialized properties. Useful to make sure typos do not occur and to be able to track back the variable usages. </summary>
    public enum PropertyName
    {
        Action,
        Actions,
        ActionType,
        AddToPopupQueue,
        AllowMultipleClicks,
        AllowSceneActivation,
        Alpha,
        AnimateValue,
        Animation,
        AnimationCurve,
        AnimationDuration,
        AnimationEase,
        AnimationIgnoresUnityTimescale,
        AnimationType,
        Animator,
        AnimatorEvents,
        Animators,
        AnyValue,
        Arrow,
        AudioClip,
        AutoHideAfterShow,
        AutoHideAfterShowDelay,
        AutoSelectButtonAfterShow,
        AutoSelectPreviouslySelectedButtonAfterHide,
        AutoSort,
        AutoStartLoopAnimation,
        BackButton,
        BackButtonAction,
        Behavior,
        BehaviorAtStart,
        BehaviorType,
        BlockBackButton,
        BoolValue,
        ButtonAnimationType,
        ButtonCategory,
        ButtonName,
        Buttons,
        By,
        CanvasName,
        Category,
        ClickMode,
        CloseBehavior,
        Closed,
        ClosedColor,
        CloseDirection,
        CloseSpeed,
        CompareMethod,
        Container,
        ControllerName,
        CustomCanvasName,
        CustomDrawerName,
        CustomPosition,
        CustomResetValue,
        CustomSortingLayer,
        CustomSortingOrder,
        CustomStartAnchoredPosition,
        Data,
        DatabaseName,
        DebugMode,
        DeselectAnyButtonSelectedOnHide,
        DeselectAnyButtonSelectedOnShow,
        DeselectButton,
        DeselectButtonAfterClick,
        DestroyAfterHide,
        DetectGestures,
        Direction,
        DisableButtonBetweenClicksInterval,
        DisableCanvas,
        DisableCanvasWhenHidden,
        DisableGameObject,
        DisableGameObjectWhenHidden,
        DisableGraphicRaycaster,
        DisableGraphicRaycasterWhenHidden,
        DisableInterval,
        DisableTriggerAfterActivation,
        DispatchButtonClicks,
        DispatchGameEvents,
        DisplayTarget,
        DontDestroyCanvasOnLoad,
        DontDestroyControllerOnLoad,
        DoubleClickRegisterInterval,
        Down,
        DragBehavior,
        DrawerBehaviorType,
        DrawerName,
        Duration,
        DurationMax,
        DurationMin,
        Ease,
        EaseType,
        Effect,
        Elasticity,
        EnableAlternateInputs,
        Enabled,
        Event,
        ExposedParameterName,
        Fade,
        FadeOut,
        FixedSize,
        FloatValue,
        From,
        GameEvent,
        GameEvents,
        GestureType,
        GetSceneBy,
        GlobalListener,
        HideBehavior,
        HideOnAnyButton,
        HideOnBackButton,
        HideOnClickAnywhere,
        HideOnClickContainer,
        HideOnClickOverlay,
        HideProgressor,
        IgnoreListenerPause,
        IgnoreUnityTimescale,
        Image,
        Images,
        InputData,
        InputMode,
        InstantAction,
        InstantAnimation,
        IntValue,
        KeyCode,
        KeyCodeAlt,
        Labels,
        Left,
        LeftBar,
        ListenFor,
        ListenForAllGameEvents,
        ListenForAllUIButtons,
        ListenForAllUIDrawers,
        ListenForAllUIViews,
        ListenForButtons,
        LoadBehavior,
        LoadSceneMode,
        LoadSelectedPresetAtRuntime,
        LongClickRegisterInterval,
        Loop,
        LoopBehavior,
        LoopType,
        m_AlphaHitTestMinimumThreshold,
        m_AutoRebuild,
        m_borderWidth,
        m_bottomLeftCorner,
        m_bottomRightCorner,
        m_canBeDeleted,
        m_ChildHeight,
        m_ChildHeightFromRadius,
        m_ChildHeightRadiusFactor,
        m_ChildRotation,
        m_ChildWidth,
        m_ChildWidthFactor,
        m_ChildWidthFromRadius,
        m_ChildWidthRadiusFactor,
        m_Clockwise,
        m_Color,
        m_ControlChildHeight,
        m_ControlChildWidth,
        m_currentValue,
        m_debugMode,
        m_description,
        m_errors,
        m_ExpandChildHeight,
        m_ExpandChildWidth,
        m_feather,
        m_featherExpandsSize,
        m_FillAmount,
        m_FillCenter,
        m_FillClockwise,
        m_FillMethod,
        m_FillOrigin,
        m_gameEvent,
        m_gameEvents,
        m_graphId,
        m_graphModel,
        m_height,
        m_hideViews,
        m_id,
        m_inputSockets,
        m_isSubGraph,
        m_lastModified,
        m_Material,
        m_MaxAngle,
        m_MaxChildWidthFactor,
        m_MaxRadius,
        m_maxValue,
        m_MinAngle,
        m_minimumInputSocketsCount,
        m_minimumOutputSocketsCount,
        m_minValue,
        m_name,
        m_nodes,
        m_nodeType,
        m_notes,
        m_onEnterHideViews,
        m_onEnterShowViews,
        m_onExitHideViews,
        m_onExitShowViews,
        m_outputSockets,
        m_OverrideSprite,
        m_PreserveAspect,
        m_Radius,
        m_RadiusControlsHeight,
        m_RadiusControlsWidth,
        m_RadiusHeightFactor,
        m_RadiusWidthFactor,
        m_RaycastTarget,
        m_RotateChildren,
        m_showViews,
        m_Spacing,
        m_Sprite,
        m_StartAngle,
        m_subGraph,
        m_topLeftCorner,
        m_topRightCorner,
        m_Type,
        m_version,
        m_wholeNumbers,
        m_width,
        m_x,
        m_y,
        MaxValue,
        MinimumSize,
        MinValue,
        Mode,
        Move,
        Multiplier,
        Name,
        NormalLoopAnimation,
        NumberOfLoops,
        OnActiveSceneChanged,
        OnAnimationEvent,
        OnAnimationFinished,
        OnAnimationStart,
        OnClick,
        OnDeselected,
        OnDisableResetValue,
        OnDoubleClick,
        OnEnableResetValue,
        OnFinished,
        OnGestureEvent,
        OnInverseProgressChanged,
        OnInverseVisibilityChanged,
        OnLoadScene,
        OnLongClick,
        OnOrientationEvent,
        OnPointerDown,
        OnPointerEnter,
        OnPointerExit,
        OnPointerUp,
        OnProgressChanged,
        OnRightClick,
        OnSceneLoaded,
        OnSceneUnloaded,
        OnSelected,
        OnStart,
        OnToggleOff,
        OnToggleOn,
        OnTrigger,
        OnValueChanged,
        OnVisibilityChanged,
        OpenBehavior,
        Opened,
        OpenedColor,
        OpenSpeed,
        OutputAudioMixerGroup,
        Overlay,
        OverrideAlpha,
        OverrideColor,
        OverrideTarget,
        OverrideTargetFsm,
        ParameterName,
        ParticleSystem,
        PercentageOfScreen,
        Pitch,
        Prefix,
        PresetCategory,
        PresetName,
        Progressor,
        Progressors,
        ProgressTargets,
        PunchAnimation,
        RandomDuration,
        RectTransform,
        ResetAfterDelay,
        ResetDelay,
        ResetOnDisable,
        ResetOnEnable,
        ResetSequenceAfterInactiveTime,
        ResetTrigger,
        Right,
        RightBar,
        Root,
        Rotate,
        RotateMode,
        Rotator,
        Scale,
        SceneActivationDelay,
        SceneBuildIndex,
        SceneName,
        Selectable,
        SelectButton,
        SelectedButton,
        SelectedLoopAnimation,
        SequenceResetTime,
        ShowBehavior,
        ShowProgressor,
        Size,
        SortingSteps,
        SoundAction,
        SoundData,
        SoundName,
        Sounds,
        SoundSource,
        SpatialBlend,
        SpriteRenderer,
        StartDelay,
        StateAnimation,
        StopBehavior,
        Suffix,
        SwipeDirection,
        SwitchBackMode,
        TargetFsm,
        TargetGameObject,
        TargetLabel,
        TargetMixer,
        TargetOrientation,
        TargetParameterType,
        TargetProgress,
        TargetValue,
        TargetVariable,
        Text,
        TextLabel,
        TextMeshPro,
        TextMeshProLabel,
        To,
        ToggleProgressor,
        Tolerance,
        TriggerAction,
        TriggerEventsAfterAnimation,
        TriggerMaxValue,
        TriggerMinValue,
        TriggerValue,
        UIButtonTriggerAction,
        UIDrawerTriggerAction,
        UIViewTriggerAction,
        Up,
        UpdateHideProgressorOnShow,
        UpdateShowProgressorOnHide,
        UseCustomFromAndTo,
        UseCustomStartAnchoredPosition,
        UseLogarithmicConversion,
        UseMultiplier,
        UseUnscaledTime,
        Vibrato,
        ViewCategory,
        ViewName,
        VirtualButtonName,
        VirtualButtonNameAlt,
        Volume,
        WaitFor,
        WaitForAnimationToFinish,
        WaitForSceneToUnload,
        Weight,
        WholeNumbers
    }
}