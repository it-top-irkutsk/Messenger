##Типы 
>Класс Msg  
> 
> Connection/Disconnection подключение / отключение от чата.
>
> CreateChat/DeleteChat используются для создания / удаления чата на сервере.
>
> Text используется для передачи сообщения. 
 
>Класс Authorization
> используется для отправки логина, пароля, подтверждения входа.
> 
>НЕ ИМЕЕТ ТИПОВ 
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
"Message":" "
}
```
Disconnection
```json
{ "Date": "18.10.2050 12:54:22", 
"Type":"Disconnection", 
"NameChat":"Chat 11", 
"SenderName":"Коля", 
"Message":" "
}
```
CreateChat
```json
{
  "Date": "18.10.2050 12:54:22",
  "Type":"CreateChat",
  "NameChat":"Chat 11",
  "SenderName":"Коля",
  "Message":" "
}
```
DeleteChat
```json
{
  "Date": "18.10.2050 12:54:22",
  "Type":"DeleteChat",
  "NameChat":"Chat 11",
  "SenderName":"Коля",
  "Message":" "
}
```