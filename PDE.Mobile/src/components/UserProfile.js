import React from 'react';
import { View, StyleSheet } from 'react-native';
import { DrawerItem, DrawerContentScrollView, } from '@react-navigation/drawer';
import {  Avatar, Title, Caption,  Drawer, Text, TouchableRipple, Switch, IconButton } from 'react-native-paper';
import { MaterialCommunityIcons } from '@expo/vector-icons';
import { useApp } from '../AppContext';

export default function UserProfile(props) {

  const { usuario, logOut } = useApp();

  return (
    <DrawerContentScrollView>
      <View style={ styles.drawerContent }>

        <View style={styles.userInfoSection}>
          <Avatar.Image source={ require('../../assets/userDefault.png')} size={50} />
          <Title style={styles.title}>{usuario.Nombres} {usuario.Apellidos}</Title>
      	  <Caption style={styles.caption}>Aqui va el cargo</Caption>
          <IconButton style={{position: 'absolute', right: 0, bottom: -10}} icon={({ color, size }) => (<MaterialCommunityIcons name="logout" color={color} size={size} onPress={()=>logOut()}/> )}/>
        </View>

        <Drawer.Section style={styles.drawerSection}>
          <DrawerItem icon={({ color, size }) => (<MaterialCommunityIcons name="application-outline" color={color} size={size} />)} label="Dashboard" onPress={()=>{props.navigation.navigate("Dashboard");}} />
          <DrawerItem icon={({ color, size }) => (<MaterialCommunityIcons name="account-multiple" color={color} size={size} /> )} label="Miembros" onPress={()=>{props.navigation.navigate('Miembros')}}/>
          <DrawerItem icon={({ color, size }) => (<MaterialCommunityIcons name="family-tree" color={color} size={size} /> )} label="Cargos" onPress={()=>{props.navigation.navigate('Cargos')}}/>
          <DrawerItem icon={({ color, size }) => (<MaterialCommunityIcons name="terraform" color={color} size={size} /> )} label="Cargos Territoriales" onPress={()=>{props.navigation.navigate('CargosTerritoriales')}}/>
        </Drawer.Section>
        
        <Drawer.Section title="Preferences"> 
          <TouchableRipple onPress={() => {}}>
            <View style={styles.preference}>
              <Text>Dark Theme</Text>
              <View pointerEvents="none">
                <Switch value={false} />
              </View>
            </View>
          </TouchableRipple>
        </Drawer.Section>

      </View>
    </DrawerContentScrollView>
  );
}

const styles = StyleSheet.create({
  drawerContent: {
    flex: 1,
  },
  userInfoSection: {
    paddingLeft: 20,
  },
  title: {
    marginTop: 20,
    fontWeight: 'bold',
  },
  caption: {
    fontSize: 14,
    lineHeight: 14,
  },
  row: {
    marginTop: 20,
    flexDirection: 'row',
    alignItems: 'center',
  },
  section: {
    flexDirection: 'row',
    alignItems: 'center',
    marginRight: 15,
  },
  paragraph: {
    fontWeight: 'bold',
    marginRight: 3,
  },
  drawerSection: {
    marginTop: 15,
  },
  preference: {
    flexDirection: 'row',
    justifyContent: 'space-between',
    paddingVertical: 12,
    paddingHorizontal: 16,
  },
});


