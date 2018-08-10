using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfPhotoGallery
{

    /// <summary>
    /// App.xaml에 대한 상호 작용 논리
    /// </summary>
    /// <remarks>
    ///   + WPF (Windows Presentation Foundation) : 세련되고 편리한 사용자 인터페이스를 개발자와 디자이너의 협업을 통해 보다 쉽게 만들 수 있는 통합환경 제공해 높은 생산성과 강력한 기능 지원.
    ///         2D, 3D, 비디오, 음성인식 기능 등의 기술이 서로 잘 작동하도록 긴밀한 통합성을 제공하여 성격이 다른 개별 분야 간에 서로 일관성 있는 결과. 
    ///         그래픽을 좀 더 부드럽게 표현하는 하드웨어 가속 기능뿐만 아니라 그래픽 작업에 특화된 GPU오 작업로드가 분산되어 좀 더 나은 성능향상을 꾀함.
    ///         프로그래밍 코드 없이도 컨트롤 개조가 가능하고 동일한 코드로 외형을 쉽게 바꿀 수 있는 스킨 기능을 제공.
    ///         윈도우 인스톨러를 클릭원스를 통한 전통적 배포방식이나 웹브라우저를 통한 프로그램 실행 지원.
    ///         대부분 사용자지정 어트리뷰트를 사용해 XML 엘리먼트 안쪽의 내용과 관계없이 프로퍼티 설정가능하도록 설계.
    ///   + XAML (eXtensible Application Makup Language) : 객체를 초기화하거나 생성하기에 적합하도록 설계된 선언형 프로그래밍 언어. 닷넷의 API만 사용.
    ///         System.Windows.Markup에 있는 타입들과 매핑되고 XAML 컴파일러나 파서에서 사용하는 특별한 지시자들을 정의.
    ///       - Property Element : XAML이 표현이 다소 길어지는 단점을 감수하고 복잡한 프로퍼티를 설정할 수 있게 제공하는 대안. 
    ///                           예: <타입명><타입명.프로퍼티명> 어떤 복잡한 설정 </타입명.프로퍼티명></타입명>
    ///       - Type Converter : XALM 파서나 컴파일러가 문자열을 적절한 데이터 타입으로 바꿔주기 위해 제공하는 컨버터.
    ///       - { 마크업확장 } : 마크업확장식에서 사용할 수도 있고 정상적인 형변환 과정을 거치는 문자열로도 쓰일 수 있다.
    ///           1. 쉼표로 구분되는 파라미터
    ///           2. NullExtension : 프로퍼티에 Null 값을 설정하는 것으로 지양.
    ///           3. StaticExtension : static 속성의 프로퍼티, 필드, 상수, 열거형을 사용할 수 있게 지원.
    ///           
    ///   + 의존 프로퍼티 구현 
    ///      : 의존프로퍼티를 구현하면 스태틱변수이기때문에 메모리 절약효과가 있고, 스레드 접근이나 재 렌더링되어야 하는 엘리먼트를 알려주는 지시자 등 체크해야 할 많은 코드를 집중화 표준화 가능.
    ///      - 1. 범용접근 스태틱 멤버변수 선언: public static readonly DependencyProperty [의존프로퍼티명Property];
    ///      - 2. 생성자에서 프로퍼티 등록 : 
    ///           [클래스명].[의존프로퍼티명Property] = DependencyProperty.Register("의존프로퍼티명"
    ///                                                                            , type(의존프로퍼티타입)
    ///                                                                            , type(클래스명)
    ///                                                                            , new FrameworkPropertyMetadata(기본값, new PropertyChangeCallback(변경통보델리게이트))
    ///                                                                            );
    ///      - 3. 프로퍼티 변경시 호출되는 콜백메서드 :
    ///           private static void 변경통보델리게이트(DependencyObject o, DependencyPropertyChangedEventArgs e) { ... }
    ///           
    ///      -  첨부 프로퍼티(Attached Property) : 임의의 객체에 추가하기 위해 사용하는 특별한 의존프로퍼티. 의SetXX, GetXX
    ///           
    ///   + 변경통보 : WPF 프로퍼티는 메터데이터의 의존해서 변경내용을 자동으로 통지 가능. 
    ///      - 1. 프로퍼티 트리거
    ///      - 2. 데이터 트리거
    ///      - 3. 이벤트 트리거
    ///      
    ///   + 라우티드 이벤트 구현
    ///     1. 범용접근 스태틱 멤버변수 선언 : public static readonly RoutedEvent [이벤트명Event];
    ///     2. 생성자에서 이벤트 등록
    ///        [클래스명].[이벤트명Event] = EventManager.RegisterRoutedEvent("이벤트명"
    ///                                                                     , RoutingStrategy.Bubble
    ///                                                                     , typeof(RoutedEventHandler)
    ///                                                                     , typeof(클래스명));
    ///     - Teunneling : 이벤트 발생 소스엘리먼트에서부터 하위 엘리먼트로 이벤트 전달
    ///     - Bubbling : 이벤트 발생 소스엘리먼트에서부터 상위 루트 엘리먼트까지 이벤트 전달
    ///     - Direct : 이벤트 발생 소스엘리먼트에서 한번만.
    ///     
    ///   + WPF 내장명령어
    ///      1. ApplicationCommands : Close, Copy, Cut, Delete, Find, Help, New, Open, Paste, Print, PrintPreview, Properties, Redo, Replace, Save, SaveAs, SelectAll, Stop, Undo 등
    ///      2. ComponentCommonds : MoveDown, MoveLeft, MoveRight, MoveUp, ScrollByLine, ScrollPageDown, ScrollPageLeft, ScrollPageRight, ScrollPageUp, SelectToEnd, SelectToHome, SelectToPageDown, SelectToPageUp 등
    ///      3. MediaCommands : ChannelDown, ChannelUp, DecreaseVolumn, FastForward, IncreaseVolume, MuteVolume, NextTrack, Pause, Play, PreviousTrack, Record, Rewind, Select, Stop 등
    ///      4. NavigationCommands : BroseBack, BrowseForward, BrowseHome, BrowseStop, Favorites. FirstPage, GoToPage, Lastpage, NextPage, PriviousPage, Refresh, Search, Zoom 등
    ///      5. EditingCommands : AlignCenter, AlignJustify, AlignLeft, AlignRight, CorrectSpellingError, DecreaseFontSize, DecreaseIndentation, EnterLineBreak, EnterParagraphBreak, IgnoreSpellingError, IncreaseFontSize, IncreaseIndentatiion 등
    ///      
    ///   + WPF 중요 클래스
    ///      - Object : 모든 닷넷 클래스의 최상위 클래스
    ///      - DispatcherObject : 스레드상에서 접근하기 원하는 임의의 객체를 위한 기반 클래스.
    ///      - DependencyObject : 의존 프로퍼티를 지원하기 위해 만들어지는 객체의 기반 클래스.
    ///      - Freezable : 성능을 읽기전용 상태인 동결될 수 있는 객체의 기반 클래스. 한번 동결된 클래스들은 멀티스레드 사이에서 안전하게 공유됨.
    ///      - Visual : 시각적으로 표현되는 모든 객체를 위한 기반 클래스.
    ///      - UIElement : 라우티드 이벤트, 명령어 바인딩, 화면배치와 포커스를 지원하는 모든 시각적 객체의 기반 클래스.
    ///      - ContentElement : 독자적인 렌더링을 하지 못하는 컨텐트의 일부 요소들을 위한 기반 클래스. (Visual 클래스에서 파생된 클래스 안에서 랜더링되어 화면상에 표시됨)
    ///      - FrameworkElement : 스타일, 데이터 바인딩, 리소스 및 툴팁이나 단축메뉴 같은 윈도우 기반 컨트롤을 위한 공통 처리 과정을 추가한 기반 클래스.
    ///      - Control : 버튼, 리스트박스 등 컨트롤들의 기반 클래스.
    ///   
    /// </remarks>
    public partial class App : Application
    {
    }

    
}
