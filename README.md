# Youtube-Subscribe-App

* This is a selenuim project written in C# for chrome.
* It Allows you to auto subscribe to a list of youtube channels stored in a csv file in a format (channel Id, Channel Link, Channel Name).
* You can choose which attribute you want to use, but by default the program will use a channel name.
* When the program runs::
     * The first step is getting the list of channel names,
     * then opens up chrome and navigates to youtube,
     * signs in using your email and password,
     * redirects to youtube and enters the name of the youtube channel,
     * and then auto subscribes.
      
   * It Does not use your existing coockies but can be modified to use them.
   * This is by far, the most inefficient way to auto subscribe to a channel since the website is constantly being updated and technologies used changed. 
