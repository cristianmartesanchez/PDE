import { StatusBar } from 'expo-status-bar';
import { View, Text } from 'react-native';
import { AppProvider, useApp } from './src/AppContext';
import theme from './src/theme';
import LogIn from './src/components/LogIn';
import Main from './src/components/Main';

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
