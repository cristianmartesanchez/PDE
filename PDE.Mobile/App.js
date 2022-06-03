import { StatusBar } from 'expo-status-bar';
import { StyleSheet, Text, View, Button } from 'react-native';
import { useEffect } from 'react';
import { AppProvider, useApp } from './src/AppContext';

function App() {
    let { logIn, usuario } = useApp();

  return (
    <View style={styles.container}>
      <Text>{usuario ? usuario.Nombres : ""} {usuario ? usuario.Apellidos : ""}</Text>
      <StatusBar style="auto" />
      <Button title="LogIn" onPress={()=> logIn("40226944128", "Pde@40226944128")}/>
    </View>
  );
}

export default () => <AppProvider><App /></AppProvider>

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff',
    alignItems: 'center',
    justifyContent: 'center',
  },
});
