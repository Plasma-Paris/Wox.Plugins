# Wox.Plugins
A few plugins for Wox (getwox.com)

Plug-In list :
 - Translator
 - Synonym

## 	Translator

###		 About 
Use MyMemory API or Yandex API for translate from many language to another

###		 Usage 
tr {source-language} {destination-language} {words} (ex: {0} en fr Hello everyone)

###		 Settings
```json
{
    "YandexApiKey": "***************************",
    "ApiName": "Yandex.Translate",
    "DefaultLanguages": [
        {
            "Source": "fr",
            "Destination": "en"
        },
        {
            "Source": "en",
            "Destination": "fr"
        }
    ]
}
```

## 	Synonym

###		 About 
Use Thesaurus Api for find synonymous for a predefined language in settings

###		 Usage 
sy {word}

###		 Settings
```json
{
    "ThesaurusApiKey": "***************************",
    "DefaultLanguage": "fr_FR"
}
```

## 	TODO 
		*Common* :
			- Readme
			- Unit Test

		*Wox.Plugin.Translator*
			- Use WPF Best Practice for SettingsForm and SettingElements view model

		*Wox.Plugin.Synonym*
			- Icon
