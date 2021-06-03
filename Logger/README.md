# Class Logger to SQLite
Класс работает с БД SQLite и записывает данные формата {Дата}{Тип сообщения}{Сообщение} в файл Log.sqlite

## Перечисления типов сообщения реализованных в классе
```LogType.Info``` Информационный  
```LogType.Success``` Успешный  
```LogType.Warning``` Предупреждение  
```LogType.Error``` Ошибка

## Функции класса Logger
```CustomLog ```функция записи кастомного лога  
**Пример**
```void CustomLog(string type,string message)```  type прием названия типа сообщения, message это сообщение  

```TypeLog ```функция записи типизированного лога   
**Пример**
```void TypeLog(LogType type,string message)``` type прием типа из перечисления LogType, message это сообщение  

```Info ```запись информации   
```Success ```запись успеха   
```Warning ```запись предупреждуния    
```Error ```запись ошибки  
**Пример**  
```void Info(string message)```  message сообщение, информационного типа записывает в БД    
```void Success(string message)```  message сообщение, успешного типа записывает в БД   
```void Warning(string message)```  message сообщение, предупредительного типа записывает в БД    
```void Error(string message)```  message сообщение, ошибочного типа записывает в БД  