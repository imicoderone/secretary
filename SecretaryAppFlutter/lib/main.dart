import 'package:flutter/material.dart';
import 'package:flutter_voice/pages/Loading.dart';
import 'package:flutter_voice/pages/LocalesList.dart';
import 'package:flutter_voice/pages/SpeechScreen.dart';

void main() {
  runApp(MyApp());
}

class MyApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Secretary',
      debugShowCheckedModeBanner: false,
      theme: ThemeData(
        visualDensity: VisualDensity.adaptivePlatformDensity,
      ),
      initialRoute: '/loading',
      routes: {
        '/loading': (context) => Loading(),
        '/locales': (context) => LocalesList(),
        '/speech': (context) => SpeechScreen(),
      },
    );
  }
}
