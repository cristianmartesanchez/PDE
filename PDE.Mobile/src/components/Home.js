import React from "react";
import { StyleSheet, Text, View, SafeAreaView, SectionList, StatusBar } from "react-native";
import { FAB } from 'react-native-paper';
import { useData } from '../DataContext';

const Item = ({ title }) => (
  <View style={styles.item}>
    <Text style={styles.title}>{title}</Text>
  </View>
);

const Home = () => {
    const { miembros } = useData();
    const DATA = [{ title: "Miembros", data: miembros.list}];
    return (
  <SafeAreaView style={styles.container}>
     <SectionList
       sections={DATA}
       keyExtractor={(item, index) => item + index}
       renderItem={({ item }) => <Item title={item} />}
       renderSectionHeader={({ section: { title } }) => (
         <Text style={styles.header}>{title}</Text>
      )}
    />
    <FAB
      style={styles.fab}
      small
      icon="plus"
      onPress={() => console.log('Pressed')}
      />
  </SafeAreaView>
    );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    paddingTop: StatusBar.currentHeight,
    marginHorizontal: 16
  },
  item: {
    backgroundColor: "#fff",
    padding: 15,
    marginVertical: 8
  },
  header: {
    fontSize: 28,
    color: '#fff',
    backgroundColor: "#196F3D"
  },
  title: {
    fontSize: 24
  },
  fab: {
    position: 'absolute',
    margin: 16,
    right: 0,
    bottom: 0,
  },
});

export default Home;

