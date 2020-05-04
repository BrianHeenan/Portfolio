## Working with Common Files  


### Starter Docs
It's a best practice to include common files when you begin a new repository. These are typically found at the top level (root) of your repository. If you don't have these setup initially, take the time to add them to your work. Here are the essentials... 

* [README.md](https://guides.github.com/features/wikis/) - Write your README using Markdown Syntax. This syntax is automatically presented to the GitHub user as HTML. The main README file typically explains what the repository contains. If your repository is for curriculum, include a Table of Contents. 
* [License](https://choosealicense.com/) (if applicable)
* [.gitignore](https://help.github.com/articles/ignoring-files/) - A .gitignore file tells git which files you never want to upload to your repository online. This is important to set-up because you never want to upload [.DS_Store files](https://www.jeffgeerling.com/blogs/jeff-geerling/stop-letting-dsstore-slow-you), and potentially other files you may have in your local repository.  

<br>

## Using Markdown

Documentation on GitHub is written in markdown syntax. GitHub will recognize a markdown file and render it as HTML for the user. The easiest way to work in markdown is to use a text editor that can preview what that will look like. MacDown is recommended. 

**Resources:**  
[MacDown:](https://github.com/MacDownApp/macdown/releases/download/v0.7.1/MacDown.app.zip) Download this helpful application for writing markdown syntax.  
[Mastering Markdown](https://guides.github.com/features/mastering-markdown/): Learn the fundamentals of writing Markdown. 

**Note:**   
To use MacDown, you may need to right-click to open/run the application the first time. 

<br> 

## Working with Invisible Files

On a Mac, any file that begins with a dot "." is invisible. To locate and work with a .gitignore file (which is invisible in Mac's Finder), you can use Terminal... 

**Step 1.** CD to the root level of your repository, e.g.: `cd ~/Desktop/RepoName`  
**Step 2.** List all files, including invisible: `ls -a`  
**Step 3.** Open and edit the .gitignore file...

`open .gitignore` 

This will open the file in a text editor. You can then easily edit and save your changes. 



**Power User Trick:** To quickly show invisible files on a Mac...

1. From the [Finder](https://support.apple.com/en-us/HT201732), type `command n` to open a new window
2. Type `command shift .` to show invisible files
3. Type the command again to hide invisible files    




