##Типы 
Connection/Disconnection используются для открытия / закрытия сокета на сервере. 

Welcome/Bye используются для приветсвия / прощания.

Text используется для передачи сообщения. 
 
### Пример json
Text
```json
{ "Date": "20.07.2015 11:43:33", 
"Type":"Text", 
"NameChat":"Chat 1", 
"SenderName":"Петя", 
"Message":"Всем большой привет"
}
```
Connection
```json
{ "Date": "18.10.2050 12:54:22", 
"Type":"Connection", 
"NameChat":"Chat 10", 
"SenderName":"Вася", 
"Message":"Запуск метода для открытия сокета"
}
```
Disconnection
```json
{ "Date": "18.10.2050 12:54:22", 
"Type":"Disconnection", 
"NameChat":"Chat 11", 
"SenderName":"Коля", 
"Message":"Запуск метода для закрытия сокета"
}
```
Welcome
```json
{ "Date": "18.10.2050 12:54:22", 
"Type":"Welcome", 
"NameChat":"Chat 11", 
"SenderName":"Коля", 
"Message":"Добро пожаловать Коля" // Любое приветствие //
}
```
Bye
```json
{ "Date": "18.10.2050 12:54:22", 
"Type":"Bye", 
"NameChat":"Chat 11", 
"SenderName":"Коля", 
"Message":"Досвидания Коля" // Любое прощание //
}
```