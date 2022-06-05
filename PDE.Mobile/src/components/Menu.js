import {createDrawerNavigator} from '@react-navigation/drawer';
import {NavigationContainer} from '@react-navigation/native';
import UserProfile from './UserProfile';
import Home from './Home';
import { useState } from 'react';
import Miembros from './Miembros';
import Cargos from './Cargos';
import CargosTerritoriales from './CargosTerritoriales';

const Drawer = createDrawerNavigator();

function Menu()
{
    return (
	<NavigationContainer>
	  <Drawer.Navigator initialRouteName="Dashboard" drawerContent={(props) => <UserProfile {...props} />}>
	    <Drawer.Screen name="Dashboard" component={Home}/> 
	    <Drawer.Screen name="Miembros" component={Miembros}/> 
	    <Drawer.Screen name="Cargos" component={Cargos}/> 
	    <Drawer.Screen name="CargosTerritoriales" component={CargosTerritoriales}/> 
	  </Drawer.Navigator>
	</NavigationContainer>
    );
}

export default Menu;
