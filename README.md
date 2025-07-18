## 전주대학교 유니티 특강 내용 백업 리포지토리
> It is The Dept of Game Contents in JeonJu University's Unity 3d Lecture Repositories.

#### Day1 - Basic Setting

|  구분   |유니티 씬 뷰 구도 잡기                                 |
|---------|------------------------------------------------------|
| 포커싱 | 게임 오브젝트 선택 후 F키                              |
|구도 잡기 | Alt키를 누른 상태에서 왼쪽 드래그                     |
| 카메라 이동 | 마우스 우클릭 + WASD(이동), QE (고동변경)          |
|메인 카메라 게임 오브젝트에 고정 | Align With view (Ctrl+shift+F)|

#### 필요 프로그램
>2018년 당시에는 visual studio를 이용했으나, 지원하는 프로그램이 많아 설치가 오래걸리고 용량도 높았었고 직관적이지 않아 여러모로 불편했음. 심지어 가볍지도 않아서 부팅시 오래걸림.
>2025년 기준으로 필요한 설치 프로그램들로 바뀐 게 있으니 설명 참고 바람.

1. [Visual Studio Code 설치](https://code.visualstudio.com/)
> Visual studio 2017 Community에서 Visual studio Code로 대체

2. [Git 설치](https://git-scm.com/)
> Git 설치 (GitHub Desktop 또는 VS Code에서 풀,푸시 가능)

#### git 사용법
1. 깃 설치시 오른쪽 클릭할 때 'Open git Bash'가 뜨도록 설치
2. 깃에 올릴 폴더를 오른쪽 클릭하여 git Bash로 열면 해당 위치에 자동으로 깃이 설정된다.
```
C104@DESKTOP-3IT1P6P MINGW64 /c/class250615/react (main)
$ git init (저장소 초기화)
Reinitialized existing Git repository in C:/class250615/react/.git/


C104@DESKTOP-3IT1P6P MINGW64 /c/class250615/react (main)
$ git remote add origin https://github.com/GAMGO/react.git (깃 리포지토리 등록)

```
