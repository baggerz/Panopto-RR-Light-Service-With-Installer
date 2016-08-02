//Stop recorder and turn light off
private static bool ActionRRStopped(
	StateMachine control,
	RRState currentState,
	StateMachineInputArgs inputArgs
	)
{
	Trace.TraceWarning("ActionRRStopped", DateTime.Now);
	control.light.ChangeColor(BusylightColor.Off);
	return true;
}

//Pause recorder and flash red light
private static bool ActionRRIsPaused(
	StateMachine control,
	RRState currentState,
	StateMachineInputArgs inputArgs
	)
{
	Trace.TraceWarning("ActionRRIsPaused", DateTime.Now);
	control.light.ChangeColor(BusylightColor.Red, false);
	return true;
}

//Resume recorder after pause and turn red light on
private static bool ActionRRRecording(
	StateMachine control,
	RRState currentState,
	StateMachineInputArgs inputArgs
	)
{
	Trace.TraceWarning("ActionRRRecording", DateTime.Now);
	control.light.ChangeColor(BusylightColor.Red);
	return true;
}

//Turn light off for preview
private static bool ActionPreview(
	StateMachine control,
	RRState currentState,
	StateMachineInputArgs inputArgs
	)
{
	Trace.TraceWarning("ActionPreview", DateTime.Now); 
	control.light.ChangeColor(BusylightColor.Off);
	return true;
}

//Turn light flashing blue
private static bool ActionRRFaultOrDisconnect(
	StateMachine control,
	RRState currentState,
	StateMachineInputArgs inputArgs
	)
{
	Trace.TraceWarning("ActionRRFaultOrDisconnect", DateTime.Now);
	control.light.ChangeColor(BusylightColor.Blue,false);
	return true;
}