using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// 채팅 메시지 규칙
    /// </summary>
    enum MESSAGE
    {
        /// <summary>
        /// 채팅 초기화 정보
        /// </summary>
        CTOC_CHAT_INITIAL_INFO,
        /// <summary>
        /// 새로운 메시지 입력신호
        /// </summary>
        CTOC_CHAT_NEWTEXT_INFO,
        /// <summary>
        /// 채팅 메시지 정보
        /// </summary>
        CTOC_CHAT_MESSAGE_INFO,
        /// <summary>
        /// 채팅 메시지
        /// </summary>
        CTOC_CHAT_MESSAGE_TEXT,
        /// <summary>
        /// 채팅 메시지 문자열 폰트
        /// </summary>
        CTOC_CHAT_MESSAGE_FONT,
        /// <summary>
        /// 채팅 메시지 문자열 색상
        /// </summary>
        CTOC_CHAT_MESSAGE_COLOR,
        /// <summary>
        /// 채팅 종료 정보
        /// </summary>
        CTOC_CHAT_TEMMINATE_INFO
    }

    class Message
    {
    }
}
