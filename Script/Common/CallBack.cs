public delegate void CallBack();
public delegate void CallBack<T>(T arg0);
public delegate void CallBack<T, U>(T arg0, U arg1);
public delegate void CallBack<T, U, V>(T arg0, U arg1, V arg2);
public delegate void CallBack<T, U, V, W>(T arg0, U arg1, V arg2, W arg3);
public delegate void CallBack<T, U, V, W, X>(T arg0, U arg1, V arg2, W arg3, X arg4);

public delegate T CallBack_Return<T>();