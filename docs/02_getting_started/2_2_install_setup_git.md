## Install Git  

Check to see if you have git installed. In Terminal, type...

``` 
git --version 

```
Visit the [git-scm](https://git-scm.com/downloads) downloads page for the most recent version. 

The git-scm site lists [three simple ways](https://git-scm.com/book/en/v1/Getting-Started-Installing-Git) you can install git on a Mac. 


**Recommended**  
An easy way to keep your version of Git up-to-date is to use Homebrew. For security reasons, having a recent version is encouraged.   

[This article](https://medium.com/@katopz/how-to-upgrade-git-ff00ea12be18) explains how to set up Homebrew to manage your git installation.  

<br>

## Customize Settings

To effectively use Git, configure the following basic settings in Terminal...


| Setting | Terminal Command |
|:------------- |:-------------|
| User Name | git config --global user.name "John Doe" |
| eMail | git config --global user.email johnDoe@fullsail.com |
| Text Editor | git config --global core.editor nano |

User and eMail information is essential. It identifies who made changes to a repository. 

**Custom Text Editor**  
The example above sets the default text editor to Nano. Without setting your preferred text editor, Git may attempt to use the less friendly "Vim". You are welcome to customize the text editor setting to your preference. If you're just getting started with Git, [Nano](https://medium.com/linode-cube/emacs-nano-or-vim-choose-your-terminal-based-text-editor-wisely-8f3826c92a68) is recommended. 

* You can check your settings at any time with this command: `git config --list`  
* To check an individual setting type: `git config <setting>`. 

> For example: `git config user.name`

<br>
 
## Detailed Settings

Outside of customizing your name, eMail, and preferred text editor, there are many other settings you can customize into the future. 

[Details on Customization](2_2a_install_setup_git_details.md): Not required reading, but helpful to know. 



