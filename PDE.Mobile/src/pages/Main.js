import { View, Text } from 'react-native';
import { useApp } from '../AppContext';
import theme from '../theme';

function Main()
{
    const { usuario } = useApp();
    return <View style={theme.main}><Text>{usuario.Nombres} {usuario.Apellidos}</Text></View>
}

export default Main;
