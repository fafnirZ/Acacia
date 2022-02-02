# Git basics

## How to clone this repo
run this command: 
`git clone git@github.com:fafnirZ/Acacia.git`

</br>

## Common commands

- adding all changed files
    - `git add .`
- committing the changed files
    - `git commit -m "YOUR COMMIT MESSAGE"`
- creating a new branch
    - `git checkout -b {branchName}`
- checking which branch you are on
    - `git branch`
- pulling from remote branch (online)
    - `git pull`
- pushing to remote for the first time
    - `git push -u origin {branchName}`
- pushing to remote in subsequent branches
    - `git push`

</br>

## FAQ
- Q: I have a merge conflict what do I do?
- A: usually this workflow is the typical workflow you perform in terms of commands to try to fix it
    ```
    git checkout main
    git pull
    git checkout {branchName}
    git merge main
    ```
    explaination: 
    - you are fetching the latest updates from main branch
    - you are going back to your current branch
    - you are trying to merge master into your current branch 
    - you can now fix whatever merge conflicts that is now shown in your IDE



## Plugins to download
- vscode git plugin
- vscode git graph plugin

