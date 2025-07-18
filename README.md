## 전주대학교 유니티 특강 내용 백업 리포지토리
> It is The Dept of Game Contents in JeonJu University's Unity 3d Lecture Repositories.

### Day1 - Basic Setting

|  구분   |유니티 씬 뷰 구도 잡기                                 |
|---------|------------------------------------------------------|
| 포커싱 | 게임 오브젝트 선택 후 F키                              |
|구도 잡기 | Alt키를 누른 상태에서 왼쪽 드래그                     |
| 카메라 이동 | 마우스 우클릭 + WASD(이동), QE (고동변경)          |
|메인 카메라 게임 오브젝트에 고정 | Align With view (Ctrl+shift+F)|

### 필요 프로그램
>2018년 당시에는 visual studio를 이용했으나, 지원하는 프로그램이 많아 설치가 오래걸리고 용량도 높았었고 직관적이지 않아 여러모로 불편했음. 심지어 가볍지도 않아서 부팅시 오래걸림.
>2025년 기준으로 필요한 설치 프로그램들로 바뀐 게 있으니 설명 참고 바람.

1. [Visual Studio Code 설치](https://code.visualstudio.com/)
> Visual studio 2017 Community에서 Visual studio Code로 대체

2. [Git 설치](https://git-scm.com/)
> Git 설치 (GitHub Desktop 또는 VS Code에서 풀,푸시 가능)

### git 사용법
1. 깃 설치시 오른쪽 클릭할 때 'Open git Bash'가 뜨도록 설치
2. 깃에 올릴 폴더를 오른쪽 클릭하여 git Bash로 열면 해당 위치에 자동으로 깃이 설정된다.
```
C104@DESKTOP-3IT1P6P MINGW64 /c/class250615/react (main)
$ git init (저장소 초기화)
Reinitialized existing Git repository in C:/class250615/react/.git/


C104@DESKTOP-3IT1P6P MINGW64 /c/class250615/react (main)
$ git remote add origin https://github.com/GAMGO/react.git (깃 리포지토리 등록)

```
### 2018 전주대 유니티 특강 진행 내용
> 기억은 안나는데 백업해야할 코드들 보면서 어떤 기능을 구현하기 위해 그렇게 작성했나 파악이 필요함.

1. FSM 다이어그램
2. 캐릭터 세팅
  - 프로그래밍 파트 : 루트 , 스크립트, 충돌처리 컴포넌트
  - 그래픽 파트 : 모델링 , 애니메이션 
3. FSM 기본 설정 
  - FSMManager 제작, PlayerState 열거형 선언
  - 각 State별로 클래스 제작
  - PlayerFSMState 부모클래스를 제작하고 상속 관계 설정
  - FSMManager에 딕셔너리 선언
  - Awake 함수를 생성하고 모든 State 컴포넌트를 딕셔너리에 추가
  - Script Execution Order에서 FSMManager를 가장 먼저 실행하도록 설정
  - SetState 함수 생성
  - PlayerFSMState에 BeginState라는 가상 함수 추가
4. IDLE/RUN FSM 구현
  - 마우스 클릭시 Raycast를 사용해 목적지 파악
  - Marker 태그를 사용해 마커를 제작하고 목적지 설정에 사용
  - Vector3.MoveTowards 함수를 사용해 목적지까지 이동
  - Quaternion.RotateTowards 함수를 사용해 목적지 방향을 향해 회전
  - 캡슐에서 캐릭터 모델링으로 교체
  - 각 State 클래스의 BeginState 함수에서 해당 애니메이션을 재생
  - 트랜스폼 이동을 캐릭터컨트롤러 이동으로 변경
5. CHASE/ATTACK FSM 구현
  - Ground와 Monster 레이어 설정
  - layerMask 값을 설정하고 이를 Raycast에 적용
  - 검출된 레이어 값을 바탕으로 RUN 상태 혹은 CHASE 상태로 분기
  - Monster레이어가 검출되면 Target 에 값 지정
  - 공격 범위 내에 도달하면 ATTACK 상태로 변경
6. 애니메이션(메카님) 설정
  - 캐릭터 릭(Rig)을 Generic으로 설정
  - 애니메이터 컴포넌트로 변경 후 기존 Animation 구문 모두 제거 
  - 애니메이터 컨트롤러를 생성한 후 Animator에 설정
  - 애니메이터 컨트롤러에 State와 Transition을 제작
  - CurrentState라는 파라미터(Parameter)를 생성하고 트랜지션에 적용
  - 스크립트에서 애니메이터 컨트롤러에 전달
7. 슬라임 루트에 SlimeFSMManager와 4개의 State 클래스 추가
8. SlimeFSMManager 우선순위를 높게 설정
9. 공격 구현
  - 공격 상태에서 상대방을 향해 회전하는 기능 추가
  - 공격 범위를 벗어나면 CHASE 상태로 변경 
  - 3인칭 시점을 제작하기 위한 CameraRig 설정
  - 공격 애니메이션에서 AttackHitCheck 이벤트 설정
  - PlayerAnimEvent 스크립트를 Animator가 위치한 게임 오브젝트에 배치
10. 공격과 데미지 구현
  - SlimeAnimEvent 스크립트를 Animator가 위치한 게임 오브젝트에 배치
  - CharacterStat에 hp와 attackRate추가
  - FSMManager에서 공격 체크를 하도록 설정 변경 
  - CharacterStat에서 대미지 처리하는 함수를 생성
  - FSMManager에서 대미지 처리하는 함수 호출
11. 몬스터 데미지 및 사망 처리
  - SlimeDEAD 스크립트를 생성한 후 컴포넌트로 추가하고, SlimeFSMManager에 DEAD상태 추가
  - CharacterStat에서 죽으면 SlimeDEAD상태로 변경
  - 막타 캐릭터 정보를 저장
  - 때린 캐릭터에게 죽었다는 신호를 알림.
  - IFSMManager 인터페이스 스크립트를 생성하고 FSMManager와 SlimeFSMManager 선언에 인터페이스 추가
  - FSMManager와 SlimeFSMManager 클래스에 인터페이스의 함수를 public으로 구현
  - CharacterStat에서 IFSMManager로 manager를 변경하고 SetDead와 NotifyDead를 호출
12. 플레이어 사망 처리
  - PlayerDEAD 스크립트 추가하고 Player에 컴포넌트로 설정
  - FSMManager의 PlayerState에 DEAD를 추가하고 딕셔너리에 PlayerDEAD를 추가
  - FSMManager의 SetDead 함수 구현
  - FSMManager에서 PlayerState가 DEAD면 SetState와 Update 함수가 바로 끝나도록 변경
  - 플레이어 Animator Controller에 DEAD 상태 애니메이션 설정 
  - SlimeFSMManager에 AttackCheck함수 생성
  - SlimeAnimEvent에서 SlimeFSMManager의 AttackCheck함수를 호출하도록 설정
13. 플레이어, 몬스터 , 필드 최종 구축
  - SlimeFSMManager에서 NotifyDead 함수에서 playerCC를 null로 설정하는 코드 추가
  - SlimePATROL과 SlimeIDLE에 playerCC가 null이 아닌지 판단하는 코드 추가
  - SlimeFSMManager과 FSMManager의 AttackCheck 함수에서 Attack 상태인지 판단하는 코드를 추가
  - AttackPoint 패키지 임포트하고 AttackPoint 프리팹을 씬에 배치 
  - FSMManager에서 두 마커를 변수로 추가한 후 초기화
  - 각 state별로 마커 게임 오브젝트의 활성화 상태를 설정
  - 몬스터 클릭시 attackMarker를 클릭한 몬스터 자식 트랜스폼으로 설정
  - 플레이어와 슬라임 모두 DEAD 상태에서 CharacterController 컴포넌트를 비활성화
  - 슬라임이 죽었을 때 Destroy 함수를 사용해 일정 시간이 지난 후에 소멸되도록 설정
  - 슬라임이 죽었을 때 attackMarker의 트랜스폼을 최상단으로 다시 재설정
  - CharacterStat에 경험치 필드 추가
  - 막타 때린 캐릭터에 경험치를 추가
