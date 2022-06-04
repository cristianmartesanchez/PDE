import { StatusBar } from 'expo-status-bar';
import { View } from 'react-native';
import { AppProvider, useApp } from './src/AppContext';
import LogIn from './src/pages/LogIn';
import theme from './src/theme';
import Main from './src/pages/Main';

function App()
{
    const { usuario } = useApp();
    return (
	<View style={theme.container}>
	  <StatusBar style="auto" />
	  {!usuario ? <LogIn /> : <Main />} 
	</View>
    );
}


export default () => <AppProvider><App /></AppProvider>
