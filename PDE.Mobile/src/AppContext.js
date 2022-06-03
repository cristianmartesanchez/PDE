import React, { useState, useEffect, useMemo } from 'react';
import axios from 'axios';

const AppContext = React.createContext();

export function AppProvider(props){
    const [usuario, setUsuario] = useState(null);
    const [token, setToken] = useState(null);
    const [expiration, setExpiration] = useState(null);
    const url = "http://10.0.0.8:5050/api/";

    function logIn(username, password)
    {
	let _url = url+"authenticate/login";
	axios.post(_url, {username, password})
	.then(resp => {
	    setUsuario(JSON.parse(resp.data.user));
	    setToken(resp.data.token);
	    setExpiration(resp.data.expiration);
	})
	.catch(err => console.log(error));
    }

    function logOut()
    {
	setUsuario(null);
	setToken(null);
	setExpiration(null);
    }

    const value = useMemo(() =>
	{
	    return({
		usuario,
		token,
		expiration,
		logIn,
		logOut
	    })
	}, [usuario, token, expiration]);

    return <AppContext.Provider value={value} {...props} />
}

export function useApp(){
    const context = React.useContext(AppContext);
    if(!context)
	throw new Error("<<useApp>> debe estar dentro del proveedor <<AppContext>>")
    return context;
}

