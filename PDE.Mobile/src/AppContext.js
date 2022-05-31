import React, { useState, useEffect, useMemo } from 'react';
import axios from 'axios';

const AppContext = React.createContext();

export function AppProvider(props){
    const usuario = "prueba exitosa";
    let url = "https://localhost:7295\\api\\";

    function logIn(username, password)
    {
	let _url = url+="authenticate\\login"
	axios.post(_url,{"username": username, "password": password})
	.then(resp => console.log(resp.data));
    }

    function logOut()
    {}

    const value = useMemo(() =>
	{
	    return({
		usuario,
		logIn,
		logOut
	    })
	}, [usuario]);

    return <AppContext.Provider value={value} {...props} />
}

export function useApp(){
    const context = React.useContext(AppContext);
    if(!context)
	throw new Error("<<useApp>> debe estar dentro del proveedor <<AppContext>>")
    return context;
}

