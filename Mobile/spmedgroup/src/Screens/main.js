import React, { Component } from 'react';
import {
    Image,
    StatusBar,
    StyleSheet,
    View,
    FlatList
} from 'react-native';
import {
    createDrawerNavigator,
    DrawerContentScrollView,
    DrawerItemList,
    DrawerItem,
  } from '@react-navigation/drawer';
import { NavigationContainer } from '@react-navigation/native';
import AsyncStorage from '@react-native-async-storage/async-storage';

import { useNavigation } from '@react-navigation/native';

import Home from './home';
import Consultas from './consultas';
import Perfil from './perfil';

const DrawerNavigator = createDrawerNavigator();

function CustomDrawerContent(props) {
    const Navigation = useNavigation();
    return (
      <DrawerContentScrollView {...props}>
        <DrawerItemList {...props} />
        <DrawerItem label="Logout" onPress={async () => {
            await AsyncStorage.removeItem('usuario-login');
            Navigation.navigate('Login');
        }} />
      </DrawerContentScrollView>
    );
  }

export default Main = () => {
    return (
        <DrawerNavigator.Navigator initialRouteName="Home" drawerContent={(props) => <CustomDrawerContent {...props} />}>
            <DrawerNavigator.Screen name="Home" component={Home}></DrawerNavigator.Screen>
            <DrawerNavigator.Screen name="Consultas" component={Consultas}></DrawerNavigator.Screen>
            <DrawerNavigator.Screen name="Perfil" component={Perfil}></DrawerNavigator.Screen>
        </DrawerNavigator.Navigator>
    )
}