import 'package:flutter/material.dart';
import 'package:flutter_spinkit/flutter_spinkit.dart';
import 'package:speech_to_text/speech_to_text.dart' as stt;

const LANGUAGES = ['en_GB', 'ru_RU', 'uz_UZ'];

class Loading extends StatefulWidget {
  @override
  _LoadingState createState() => _LoadingState();
}

class _LoadingState extends State<Loading> {
  void getLocales() async {
    stt.SpeechToText _speech = stt.SpeechToText();
    await _speech.initialize();
    await Future.delayed(Duration(seconds: 3));
    var _locales = await _speech.locales();
    var _availableLocales =
        _locales.where((lan) => LANGUAGES.contains(lan.localeId));
    Navigator.pushReplacementNamed(context, '/locales',
        arguments: {'locales': _availableLocales});
  }

  @override
  void initState() {
    super.initState();
    getLocales();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        backgroundColor: Colors.blue[900],
        body: Center(
          child: SpinKitFadingCube(
            color: Colors.white,
            size: 80.0,
          ),
        ));
  }
}
