import { View, TextInput, Button } from 'react-native';
import { useState } from 'react';
import { useApp } from '../AppContext';
import theme from '../theme';

export default function LogIn()
{
    const [cedula, setCedula] = useState(null);
    const [password, setPassword] = useState(null);
    const { logIn } = useApp();

    return <View style={theme.logIn}>
	  <TextInput value={cedula} onChangeText={setCedula} placeholder="Cédula"/>
	  <TextInput value={password} onChangeText={setPassword} secureTextEntry={true} placeholder="Contraseña" />
	  <Button color={theme.logIn.accessButton.color} onPress={() => logIn(cedula, password)} title="Acceder"/>
	</View>
}

