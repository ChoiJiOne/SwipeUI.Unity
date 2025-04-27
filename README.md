# SwipeUI.Unity
- 유니티를 이용한 스와이프 UI 만들기 연습 프로젝트입니다.

## 유니티 엔진 버전
- `6000.0.40f1`

## 목표
- 유니티를 활용한 스와이프 UI 구현
- 참고 자료 기반의 기능 분석 및 개선 사항 적용

## 사용 패키지
- [DOTween](https://dotween.demigiant.com/)

## 에디터 세팅
- Game 탭 해상도 1080x1920 으로 설정

## 개선 사항
- 동적 컨텐츠 확장 지원
  - 기존: 참고 자료에는 컨텐츠 하위 오브젝트 수가 고정되어 있고, 관련 로직도 이에 맞춰 하드코딩
  - 변경: 컨텐츠 하위 오브젝트가 동적으로 추가되거나 삭제되더라도 정상적으로 작동하도록 개선
- 이벤트 처리 방식 개선
  - 기존: PC와 모바일 디바이스의 입력 이벤트를 별도로 처리
  - 변경: Unity의 드래그 인터페이스에 맞는 `OnBeginDrag`/`OnDrag`/`OnEndDrag` 구조로 재구성하여 이벤트 흐름 일관성 확보

## 구현 결과

![Result](./Image/Result.gif)

## 참고 자료
- [[Unity Basic Skills] 16. UGUI - Layout Components](https://www.youtube.com/watch?v=Cv3oQxjf1As&t=9s)
- [How to make a DRAG & DROP UI in Unity!](https://www.youtube.com/watch?v=uTeZz4O12yU)
- [How to make a SWIPE UI in Unity!](https://www.youtube.com/watch?v=zeHdty9RUaA&t=78s)
