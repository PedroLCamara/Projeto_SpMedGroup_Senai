import React, { Component } from 'react';
import {
    ImageBackground,
    SafeAreaView,
    ScrollView,
    StatusBar,
    StyleSheet,
    Text,
    TextInput,
    TouchableOpacity,
    useColorScheme,
    View,
    Image
} from 'react-native';
import {
    Colors,
    DebugInstructions,
    Header,
    LearnMoreLinks,
    ReloadInstructions,
} from 'react-native/Libraries/NewAppScreen';

export default class Home extends Component {

    RedirecionarConsultas = () => {
        this.props.navigation.navigate('Consultas');
    }

    render() {
        return (
            <View style={styles.Main}>
                <ImageBackground style={styles.GrafismoHome} source={require('../../assets/VectorHome.png')}>
                    <Text style={styles.TituloHome}>
                        Sp Medical Group
                    </Text>
                </ImageBackground>
                <View style={styles.SectionHome}>
                    <Text style={styles.TextoSectionHome}>Acesse e administre suas consultas, futuras ou já realizadas em qualquer lugar e de qualquer lugar </Text>
                    <View style={styles.ElementosSectionHome}>
                        <Image source={require('../../assets/Vector.png')}></Image>
                        <TouchableOpacity style={styles.BotaoSectionHome} onPress={this.RedirecionarConsultas}>
                            <Text style={styles.TextoBotaoSectionHome}>Ir às minhas consultas</Text>
                        </TouchableOpacity>
                    </View>
                </View>
                <View style={styles.Overlay}></View>
            </View>
        )
    }
}

const styles = StyleSheet.create({
    Main: {
        flex: 1,
        backgroundColor: '#FFF',
        alignItems: 'center',
    },
    GrafismoHome: {
        width: '100%',
        height: 290,
        justifyContent: 'center',
        alignItems: 'center'
    },
    TituloHome: {
        color: '#FFF',
        fontSize: 40,
        width: 200,
        textAlign: 'center'
    },
    SectionHome: {
        width: 300,
        height: 200,
        marginTop: 20,
        padding: 25,
        borderColor: '#BFBFBF',
        borderWidth: 1,
        borderRadius: 20,
        flexDirection: 'row',
        alignItems: 'center',
        backgroundColor: '#FFF'
    },
    TextoSectionHome: {
        width: 130,
        fontSize: 14
    },
    ElementosSectionHome: {
        height: '100%',
        alignItems: 'center',
        justifyContent: 'space-between',
    },
    BotaoSectionHome: {
        width: 115,
        height: 40,
        justifyContent: 'center',
        alignItems: 'center',
        borderRadius: 10,
        backgroundColor: '#5FAD9E'
    },
    TextoBotaoSectionHome: {
        color: '#FFF',
        textAlign: 'center'
    }
})