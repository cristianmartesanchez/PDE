import React, { useState, useEffect, useMemo } from 'react';
import axios from 'axios';
import { useApp } from './AppContext';

const DataContext = React.createContext();

export function DataProvider(props){
    const url = "http://192.168.137.1:5295/api/";
    const { usuario } = useApp();

    const value = useMemo(() =>
	{
	    return({
		miembros:{
		    list: ["Pizza", "Burger", "Risotto", "Calzoni", "ChickenBaque", "IceCream", "CheeseCacke", "Rize", "Milk", "Beans"] 
		},
		cargos:{
		    list: ["Pizza", "Burger", "Risotto", "Calzoni", "ChickenBaque", "IceCream", "CheeseCacke", "Rize", "Milk", "Beans"]
		},
		cargosTerritoriales:{
		    list: ["Pizza", "Burger", "Risotto", "Calzoni", "ChickenBaque", "IceCream", "CheeseCacke", "Rize", "Milk", "Beans"]
		},
	    })
	},[usuario]);

    return <DataContext.Provider value={value} {...props} />
}

export function useData(){
    const context = React.useContext(DataContext);
    if(!context)
	throw new Error("<<useData>> debe estar dentro del proveedor <<DataContext>>")
    return context;
}

