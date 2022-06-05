import {createDrawerNavigator} from '@react-navigation/drawer';
import {NavigationContainer} from '@react-navigation/native';
import UserProfile from './UserProfile';
import Home from './Home';

const Drawer = createDrawerNavigator();

function Menu()
{
    return (
	<NavigationContainer>
	  <Drawer.Navigator initialRouteName="Dashboard" drawerContent={() => <UserProfile />}>
	    <Drawer.Screen name="PDE" component={Home} />
	  </Drawer.Navigator>
	</NavigationContainer>
    );
}

export default Menu;
