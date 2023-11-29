# aspnet-sms-gateway
using the SMS gateway from 360Marketing to send the bulk SMS to the numbers in database with the particular approved messages saved in their message column to be sent to them

## SMS Gateway
the SMS Gateway is `360Marketing`
* Here the SMS Message are pre defined as approved Templates
* For API documentation visit Swagger documentation `http://164.52.205.46:6005/swagger/index.html`
* Here we are calling the Gat Request of SMS Gateway's API and in that GET request we are passing the user credentials
* From 360 Marketing we have `Send ID`, `API Key` and `Client ID`
* the Sender ID is `ITFAST`, Api Key is `Yf65Pp09pjhMIXlLFpQyhMrRJWDGunJyHV/YwXkrg8U=` and
  Client ID is `c6c7b7c0-0576-427d-9d9a-ecbd6c1a5ef5`

## Project
* Here we are creating a `GET` request and then filing its parameters liek sender id, is Unicode, is Flash, Api Key and Client Key
* This parameter of URL are then used in the whole url at calling GET request of 360Marketing's SMS Gateway
* The Scheme consists the columns of Phone Numbers, Messages and SentOn, so that the code will run aa for loop to fetch the phone numbers from DB whose SentOn is null and then assign those numbers to the GET request's URL
* Once The following SMS message has been sent on that respective number the SentOn will get the Date & TIme in order to view when the SMS was sent to this number

## Scheme Details
<table>
  <thead>
    <tr>
      <th>Column Name</th>
      <th>Data Type</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>id</td>
      <td>int</td>
    </tr>
    <tr>
      <td>MobileNumber</td>
      <td>varchar(15)</td>
    </tr>
    <tr>
      <td>Message</td>
      <td>varchar(500)</td>
    </tr>
    <tr>
      <td>SentOn</td>
      <td>datetime</td>
    </tr>
  </tbody>
</table>
