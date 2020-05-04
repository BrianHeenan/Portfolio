## Cloning a Repository  


### Use HTTPS!

Into the future, you will need to clone repositories to your computer. The easiest way to do this is to use the HTTPS protocol. 

[GitHub Help](https://help.github.com/articles/which-remote-url-should-i-use/): This article discusses cloning a repository using HTTPS or SSH URLs. It is strongly recommended that you use HTTPS. Here's how... 

While in your GitHub repository, you will see a green button that says something similar to "Clone or download". To clone (copy) your repository to your computer, use the HTTPS URL. 


![Git](https://drive.google.com/uc?id=1AfUZ8DhqLsYxiyIehDQiYox5ygimHfiZ)

**DO NOT** use the SSH url, which looks like the following...

![Git](https://drive.google.com/uc?id=1AgECFFEnt32VUY9vVhD8raYsFx6TN8_C)

 

<br>

**Why HTTPS is preferred**

1. Easier to setup (than SSH)
2. Works better behind a firewall
3. Works with Mac OSX credential helper

<br>

## GitHub Credentials

When using the HTTPS protocol with Git in Terminal, you will be asked for your GitHub username and password. For convenience sake, the recommendation is to install the *OSX Keychain Helper*. Once installed, your username and password will be stored after the first successful login. 

[GitHub Article](https://help.github.com/articles/caching-your-github-password-in-git/): Explains how to setup the OSX Keychain Helper.


