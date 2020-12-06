import 'package:flutter/material.dart';
import 'package:speech_to_text/speech_to_text.dart' as stt;

class LocalesList extends StatelessWidget {
  Map data = {};

  Widget ListViewBuilder(List<stt.LocaleName> locales) {
    return ListView.builder(
        itemCount: locales.length,
        itemBuilder: (context, index) {
          return Padding(
            padding: const EdgeInsets.symmetric(vertical: 1.0, horizontal: 4.0),
            child: Card(
              child: ListTile(
                onTap: () {
                  Navigator.pushNamed(context, '/speech',
                      arguments: {'locale': locales[index]});
                },
                title: Text(locales[index].name),
              ),
            ),
          );
        });
  }

  @override
  Widget build(BuildContext context) {
    data = ModalRoute.of(context).settings.arguments;
    List<stt.LocaleName> locales = [...data['locales']];

    return Scaffold(
      backgroundColor: Colors.blue[300],
      appBar: AppBar(
        title: Text('Tilni tanlang'),
      ),
      body: Container(
        color: Colors.grey[100],
        child: ListViewBuilder(locales),
      ),
    );
  }
}
