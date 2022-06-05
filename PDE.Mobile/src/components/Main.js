import { StatusBar } from 'expo-status-bar';
import { View, Text } from 'react-native';
import { useApp } from '../AppContext';
import theme from '../theme';
import {createDrawerNavigator} from '@react-navigation/drawer';
import {NavigationContainer} from '@react-navigation/native';
import Dashboard from './Dashboard';
import Miembros from './Miembros';
import Cargos from './Cargos';
import CargosTerritoriales from './CargosTerritoriales';

const Drawer = createDrawerNavigator();

function Main()
{
    const { usuario } = useApp();
    return (
	<NavigationContainer>
	  <Drawer.Navigator>
	    <Drawer.Screen name="Dashboard" component={Dashboard} />
	    <Drawer.Screen name="Miembros" component={Miembros} />
	    <Drawer.Screen name="Cargos" component={Cargos} />
	    <Drawer.Screen name="Cargos Territoriales" component={CargosTerritoriales} />
	  </Drawer.Navigator>
	</NavigationContainer>
    );
}

export default Main;
