import { StyleSheet } from 'react-native';

const theme = StyleSheet.create({
    container:{
	flex: 1,
    	backgroundColor: '#fff',
    },
    logIn:{
	flex:1,
    	alignItems: 'center',
    	justifyContent: 'center',
    	accessButton:{
	    color: '#229954'
    	}
    },
    main:{
	flex:1,
	alignItems: 'center',
    	justifyContent: 'center',
    }
});

export default theme;
